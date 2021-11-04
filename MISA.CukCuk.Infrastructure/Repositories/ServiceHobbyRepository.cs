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
    public class ServiceHobbyRepository :BaseRepository<ServiceHobby>, IServiceHobbyRepository
    {
        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public ServiceHobbyRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        public OutputPaging<ServiceHobby> GetServiceHobbyPaging(string filterName, int pageSize, int pageIndex)
        {
            OutputPaging<ServiceHobby> _outputPaging = new OutputPaging<ServiceHobby>();

            DynamicParameters parameters = new DynamicParameters();
            if(filterName == null)
            {
                filterName = string.Empty;
            }
            parameters.Add($"$FilterName", filterName);
            parameters.Add($"$PageSize", pageSize);
            parameters.Add($"$PageIndex", pageIndex);

            parameters.Add("$TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("$TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var res = _dbConnection.Query<ServiceHobby>("Proc_GetServiceHobbyPaging", parameters, commandType: CommandType.StoredProcedure);


            _outputPaging.Data = (List<ServiceHobby>)res;
            _outputPaging.TotalPage = parameters.Get<Int32>("$TotalPage");
            _outputPaging.TotalRecord = parameters.Get<Int32>("$TotalRecord");

            return _outputPaging;
        }
        #endregion
    }
}
