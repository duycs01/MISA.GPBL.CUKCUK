using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class MenuService : BaseService<Menu>, IMenuService
    {
        #region DECLEAR
        IMenuRepository _menuRepository;
        #endregion

        #region Contructor

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeRepository">Kết nối database</param>
        /// CreateBy duylv - 27/08/2021
        public MenuService(IMenuRepository menuRepository) : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }
        #endregion
        #region Method

        public ServiceResult CheckDuplicateMenuCode(Guid? menuId, string menuCode)
        {
            var duplicateCode = _menuRepository.CheckDuplicateMenuCode(menuId, menuCode);

            if (duplicateCode)
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Duplicate_MenuCode;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Duplicate_MenuCode;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;
            }
            else
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.NotDuplicate_MenuCode;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.NotDuplicate_MenuCode;
                _serviceResult.IsValid = true;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;

            }

            return _serviceResult;
        }

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        public ServiceResult GetMenuPaging(List<InputPaging> listInputPaging, int pageSize, int pageIndex)
        {
            var res = _menuRepository.GetMenuPaging(listInputPaging, pageSize, pageIndex);

            if (res.Data.Count > 0)
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.IsValid = true;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;
                _serviceResult.Data = res;
            }
            else
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;
                _serviceResult.Data = res;

            }
            return _serviceResult;
        }

        public ServiceResult GetNewMenuCode(string menuCode)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = menuCode.Normalize(NormalizationForm.FormD);
            var newCode = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            newCode = newCode.Replace(" ", "");
            newCode = newCode.ToUpper();

            var duplicate = _menuRepository.CheckDuplicateMenuCode(null, newCode);
            var strVal = string.Empty;
            var numbVal = string.Empty;
            var numb = 1;
            var code = newCode;

            if (duplicate)
            {
                for (int i = 0; i < newCode.Length; i++)
                {
                    if (Char.IsDigit(newCode[i]))
                    {
                        numbVal += newCode[i];
                    }
                    else
                    {
                        strVal += newCode[i];
                    }
                }
                if(numbVal != string.Empty)
                {
                    numb = int.Parse(numbVal);
                }
                do
                {
                    code = $"{strVal}{numb++}";
                } while (_menuRepository.CheckDuplicateMenuCode(null, code));

            }

            if(code !="" || code != null)
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.IsValid = true;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;
                _serviceResult.Data = code;
            }
            else
            {
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)Enum.StatusCode.Success;
                _serviceResult.Data = code;
            }
           

            return _serviceResult;
        }


        /// <summary>
        /// Thêm mới thực đơn
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        public override ServiceResult Insert(Menu menu)
        {
            var isValid = ValidateData(menu);
            if (isValid == true)
            {
                isValid = ValidateCustom(menu);
            }
            if (isValid == true)
            {
                var res = _menuRepository.InsertMenu(menu);
                if (res > 0)
                {
                    _serviceResult.Data = res;
                    _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Insert_Success;
                    _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Insert_Success;
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Created;
                }
                else
                {
                    _serviceResult.Data = res;
                    _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Insert_Error;
                    _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Insert_Error;
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
                }

            }
            return _serviceResult;
        }

        /// <summary>
        /// Sửa thực đơn
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        public override ServiceResult Update(Guid menuId, Menu menu)
        {
            menu.MenuId = menuId;

            var isValid = ValidateData(menu);
            if (isValid == true)
            {
                isValid = ValidateCustom(menu);
            }
            if (isValid == true)
            {
                var res = _menuRepository.UpdateMenu(menu);
                if (res > 0)
                {
                    _serviceResult.Data = res;
                    _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Update_Success;
                    _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Update_Success;
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
                }
                else
                {
                    _serviceResult.Data = res;
                    _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Update_Error;
                    _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Update_Error;
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
                }

            }
            return _serviceResult;
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo id
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>Trả về thông tin bản ghi theo id</returns>
        /// CreatedBy: duylv - 06/10/2021
        public override ServiceResult GetById(Guid menuId)
        {
            var res = _menuRepository.GetMenuById(menuId);
            if (res != null)
            {
                _serviceResult.Data = res;
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Success;
                _serviceResult.IsValid = true;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
            }
            else
            {
                _serviceResult.Data = res;
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Get_Error;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>Trả về số bản ghi xóa được</returns>
        /// CreatedBy: duylv - 06/10/2021
        public override ServiceResult DeleteById(Guid menuId)
        {
            var res = _menuRepository.DeleteMenu(menuId);
            if (res > 0)
            {
                _serviceResult.Data = res;
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Success;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Success;
                _serviceResult.IsValid = true;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
            }
            else
            {
                _serviceResult.Data = res;
                _serviceResult.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Error;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Error;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
            }
            return _serviceResult;
        }
        #endregion
    }
}
