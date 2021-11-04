using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.CukCuk.Core.Attributes.MISAAttribute;

namespace MISA.CukCuk.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Declaration

        IBaseRepository<MISAEntity> _baseRepository;
        protected ServiceResult _serviceResult;
        string _tableName;

        #endregion

        #region Contructor

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
            _tableName = typeof(MISAEntity).Name;

        }

        #endregion

        #region Method

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>Trả về số bản ghi xóa được</returns>
        /// CreatedBy: duylv - 29/09/2021
        public virtual ServiceResult DeleteById(Guid entityId)
        {
            var res = _baseRepository.DeleteById(entityId);
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
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.NoContent;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Lấy tất cả danh sách bản ghi
        /// </summary>
        /// <returns>Trả về danh sách bản ghi</returns>
        /// CreatedBy: duylv - 29/09/2021
        public ServiceResult GetAll()
        {
            var res = _baseRepository.GetAll();
            if (res.Count > 0)
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
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.NoContent;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo id
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>Trả về thông tin bản ghi theo id</returns>
        /// CreatedBy: duylv - 29/09/2021
        public virtual ServiceResult GetById(Guid entityId)
        {
            var res = _baseRepository.GetById(entityId);
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
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.NoContent;
            }
            return _serviceResult;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Số bản ghi thêm được</returns>
        /// CreatedBy: duylv - 29/09/2021
        public virtual ServiceResult Insert(MISAEntity entity)
        {
           
            var isValid = ValidateData(entity);
            if (isValid == true)
            {
                isValid = ValidateCustom(entity);
            }
            if (isValid == true)
            {
                var res = _baseRepository.Insert(entity);
                if(res > 0)
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
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.NoContent;
                }
             
            }
            return _serviceResult;
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entityId">Id Của bản ghi</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Số bản ghi đã sửa</returns>
        /// CreatedBy: duylv - 29/09/2021
        public virtual ServiceResult Update(Guid entityId, MISAEntity entity)
        {
            var isValid = ValidateData(entity);

            var tableId = $"{_tableName}Id";

            var prop = entity.GetType().GetProperty(tableId);
            prop.SetValue(entity, entityId);

            if (isValid == true)
            {
                isValid = ValidateCustom(entity);
            }
            if (isValid == true)
            {
                var res = _baseRepository.Update(entity);
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
                    _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.NoContent;
                }
                
            }
            return _serviceResult;
        }

        /// <summary>
        /// Sử lí validate chung
        /// </summary>
        /// <param name="entity">Đối tượng muốn validate</param>
        /// <returns>True bản ghi hợp lệ - False bản ghi không hợp lệ</returns>
        /// CreatedBy: duylv - 29/09/2021
        protected bool ValidateData(MISAEntity entity)
        {
            // validate Bắt buộc nhập
            var properties = entity.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(entity);
                var propName = prop.Name;
                var propType = prop.PropertyType;

                var propMISARequired = prop.GetCustomAttributes(typeof(MISARequired), true);

                var fieldName = string.Empty;
                if (propMISARequired.Length > 0)
                {
                    fieldName = (propMISARequired[0] as MISARequired).FieldName;
                }

                if (propMISARequired.Length > 0)
                {
                    if (propType == typeof(string) && propValue == null || propValue.ToString() == string.Empty)
                    {
                        _serviceResult.IsValid = false;
                        _serviceResult.Messenger.devMsg = $"Thông tin {fieldName} không được phép để trống";
                        _serviceResult.Messenger.userMsg = $"Thông tin {fieldName} không được phép để trống";
                        _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.BadRequest;
                    }
                }
            }
            return _serviceResult.IsValid;
        }

        /// <summary>
        /// Sử lí validate riêng
        /// </summary>
        /// <param name="entity">Đối tượng muốn validate</param>
        /// <returns>True bản ghi hợp lệ - False bản ghi không hợp lệ</returns>
        /// Created by: duylv - 29/09/2021
        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }
        #endregion
    }
}
