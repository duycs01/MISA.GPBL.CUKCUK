using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public MenuRepository(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion

        #region MeThod

        /// <summary>
        /// Kiểm tra trùng mã thực đơn
        /// </summary>
        /// <param name="menuId">Id thực đơn</param>
        /// <param name="menuCode">Mã thực đơn</param>
        /// <returns>True là trùng false là không trùng</returns>
        /// CreatedBy: duylv-30/09/2021
        public bool CheckDuplicateMenuCode(Guid? menuId, string menuCode)
        {
            DynamicParameters parameters = new DynamicParameters();

            if (menuId == null)
            {
                menuId = Guid.Empty;
            }

            parameters.Add($"$MenuId", menuId);
            parameters.Add($"$MenuCode", menuCode);

            var sqlCommand = $"Proc_CheckDuplicateMenuCode";
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        public OutputPaging<Menu> GetMenuPaging(List<InputPaging> listInputPaging, int pageSize, int pageIndex)
        {
            OutputPaging<Menu> _outputPaging = new OutputPaging<Menu>();

            DynamicParameters parameters = new DynamicParameters();

            var sqlWhere = "";



            foreach (var item in listInputPaging)
            {
                if (item.FilterName.ToString() == "")
                {
                    sqlWhere += "";
                }
                else if (item.Column == "Price" || item.Column == "TypeOfMenu")
                {
                    sqlWhere += $" {item.Column} {item.Operator} {item.FilterName} and";
                }
                else
                {
                    switch (item.Operator)
                    {
                        case "-":
                            sqlWhere += $" {item.Column} LIKE '%{item.FilterName}' and";
                            break;

                        case "+":
                            sqlWhere += $" {item.Column} LIKE '{item.FilterName}%' and";
                            break;

                        default:
                            sqlWhere += $" {item.Column} {item.Operator} '%{item.FilterName}%' and";
                            break;
                    }
                }

            }

            if (sqlWhere != "")
            {
                sqlWhere = sqlWhere.Remove(sqlWhere.Length - 3, 3);
            }

            parameters.Add($"$Where", sqlWhere);
            parameters.Add($"$Column", "");
            parameters.Add($"$Sort", "");

            parameters.Add($"$PageSize", pageSize);
            parameters.Add($"$PageIndex", pageIndex);

            parameters.Add("$TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("$TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var res = _dbConnection.Query<Menu>("Proc_GetMenuPaging", parameters, commandType: CommandType.StoredProcedure);


            _outputPaging.Data = (List<Menu>)res;
            _outputPaging.TotalPage = parameters.Get<Int32>("$TotalPage");
            _outputPaging.TotalRecord = parameters.Get<Int32>("$TotalRecord");

            return _outputPaging;
        }

        public int InsertMenu(Menu menu)
        {
            var transaction = _dbConnection.BeginTransaction();

            try
            {
                var parametersMenu = MappingDBType(menu);
                DynamicParameters parametersProcessingMenu = new DynamicParameters();
                DynamicParameters parametersServiceHobbyMenu = new DynamicParameters();

                var rowEffectMenu = _dbConnection.Execute($"Proc_InsertMenu", param: parametersMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                // thêm chế biến
                if (rowEffectMenu > 0 && menu.ListProcessing.Count > 0)
                {
                    var rowEffectsProcessingMenu = 0;

                    foreach (var item in menu.ListProcessing)
                    {
                        parametersProcessingMenu.Add("$MenuId", menu.MenuId);
                        parametersProcessingMenu.Add("$ProcessingId", item);
                        rowEffectsProcessingMenu += _dbConnection.Execute($"Proc_InsertProcessingMenu", parametersProcessingMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                    }
                }

                // thêm chọn dịch vụ
                if (rowEffectMenu > 0 && menu.ListServiceHobby.Count > 0)
                {
                    var rowEffectsServiceHobbyMenu = 0;

                    foreach (var item in menu.ListServiceHobby)
                    {
                        if (item.ServiceHobbyId != Guid.Empty)
                        {
                            parametersServiceHobbyMenu.Add("$MenuId", menu.MenuId);
                            parametersServiceHobbyMenu.Add("$ServiceHobbyId", item.ServiceHobbyId);
                            parametersServiceHobbyMenu.Add("$CollectMore", item.CollectMore);
                            rowEffectsServiceHobbyMenu += _dbConnection.Execute($"Proc_InsertServiceHobbyMenu", parametersServiceHobbyMenu, transaction: transaction, commandType: CommandType.StoredProcedure);
                        }
                    }
                }
                transaction.Commit();
                return rowEffectMenu;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 0;
            }

        }

        public int UpdateMenu(Menu menu)
        {
            var transaction = _dbConnection.BeginTransaction();
            try
            {
                var parametersMenu = MappingDBType(menu);
                DynamicParameters parametersProcessingMenu = new DynamicParameters();
                DynamicParameters parametersServiceHobbyMenu = new DynamicParameters();

                var rowEffectMenu = _dbConnection.Execute($"Proc_UpdateMenu", param: parametersMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                if (rowEffectMenu > 0 && menu.ListProcessing.Count > 0)
                {
                    var rowEffectsProcessingMenu = 0;
                    parametersProcessingMenu.Add("$MenuId", menu.MenuId);
                    rowEffectsProcessingMenu = _dbConnection.Execute($"Proc_DeleteProcessingMenu", parametersProcessingMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                    foreach (var item in menu.ListProcessing)
                    {
                        parametersProcessingMenu.Add("$MenuId", menu.MenuId);
                        parametersProcessingMenu.Add("$ProcessingId", item);
                        rowEffectsProcessingMenu += _dbConnection.Execute($"Proc_InsertProcessingMenu", parametersProcessingMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                    }
                }

                if (rowEffectMenu > 0 && menu.ListServiceHobby.Count > 0)
                {
                    var rowEffectsServiceHobbyMenu = 0;
                    parametersServiceHobbyMenu.Add("$MenuId", menu.MenuId);
                    rowEffectsServiceHobbyMenu = _dbConnection.Execute($"Proc_DeleteServiceHobbyMenu", parametersServiceHobbyMenu, transaction: transaction, commandType: CommandType.StoredProcedure);

                    foreach (var item in menu.ListServiceHobby)
                    {
                        if (item.ServiceHobbyId != Guid.Empty)
                        {
                            parametersServiceHobbyMenu.Add("$MenuId", menu.MenuId);
                            parametersServiceHobbyMenu.Add("$ServiceHobbyId", item.ServiceHobbyId);
                            parametersServiceHobbyMenu.Add("$CollectMore", item.CollectMore);
                            rowEffectsServiceHobbyMenu += _dbConnection.Execute($"Proc_InsertServiceHobbyMenu", parametersServiceHobbyMenu, transaction: transaction, commandType: CommandType.StoredProcedure);
                        }
                    }
                }
                transaction.Commit();
                return rowEffectMenu;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 0;
            }

        }

        public Menu GetMenuById(Guid menuId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("$MenuId", menuId);

            var rowEffectMenu = _dbConnection.QueryFirstOrDefault<Menu>($"Proc_GetMenuById", param: parameters, commandType: CommandType.StoredProcedure);
            if (rowEffectMenu != null)
            {
                var rowEffectProcessingMenu = _dbConnection.Query($"Proc_GetProcessingMenuById", param: parameters, commandType: CommandType.StoredProcedure);
                var rowEffectsServiceHobbyMenu = _dbConnection.Query<ServiceHobby>($"Proc_GetServiceHobbyMenuById", param: parameters, commandType: CommandType.StoredProcedure);

                if (rowEffectProcessingMenu.ToList().Count > 0)
                {
                    foreach (var item in rowEffectProcessingMenu)
                    {
                        rowEffectMenu.ListProcessing.Add(item.ProcessingId);
                    }
                }

                if (rowEffectsServiceHobbyMenu.ToList().Count > 0)
                {
                    foreach (var item in rowEffectsServiceHobbyMenu)
                    {
                        rowEffectMenu.ListServiceHobby.Add((ServiceHobby)item);
                    }
                }

            }

            return rowEffectMenu;
        }

        public int DeleteMenu(Guid menuId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("$MenuId", menuId);

            var rowEffectMenu = _dbConnection.Execute($"Proc_DeleteProcessingMenu", param: parameters, commandType: CommandType.StoredProcedure);
            rowEffectMenu += _dbConnection.Execute($"Proc_DeleteServiceHobbyMenu", param: parameters, commandType: CommandType.StoredProcedure);

            rowEffectMenu += _dbConnection.Execute($"Proc_DeleteMenuById", param: parameters, commandType: CommandType.StoredProcedure);


            return rowEffectMenu;
        }
        #endregion
    }
}
