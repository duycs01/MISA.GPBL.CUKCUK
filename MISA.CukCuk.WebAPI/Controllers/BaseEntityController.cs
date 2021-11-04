using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region DECLEAR

        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        protected ServiceResult _serviceResult;
        #endregion

        #region Contructor

        public BaseEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Trả về danh sách bản ghi</returns>
        /// Created by: duylv 29/09/2021
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            try
            {
                var res = _baseRepository.GetAll();
                if (res.Count > 0)
                {

                    return StatusCode(200, res);
                }
                else
                {
                    return StatusCode(204, res);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo id
        /// </summary>
        /// <returns>Trả thông tin bản ghi</returns>
        /// Created by: duylv 29/09/2021
        [HttpGet("{id}")]
        public virtual IActionResult GetById(Guid id)
        {
            try
            {
                var res = _baseService.GetById(id);
                return StatusCode(res.StatusCode, res);

            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <returns>Trả về số hàng được thêm vào</returns>
        /// Created by: duylv 29/09/2021
        [HttpPost]
        public virtual IActionResult Insert([FromBody] MISAEntity entity)
        {
            try
            {
                var res = _baseService.Insert(entity);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Sửa thông tin bản ghi theo id
        /// </summary>
        /// <returns></returns>
        /// Created by: duylv 29/09/2021
        [HttpPut("{entityId}")]
        public virtual IActionResult Update(Guid entityId, [FromBody] MISAEntity entity)
        {
            try
            {
                var res = _baseService.Update(entityId, entity);
                return StatusCode(res.StatusCode, res);

            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Xóa thông tin bản ghi theo id
        /// </summary>
        /// <returns></returns>
        /// Created by: duylv 29/09/2021
        [HttpDelete("{entityId}")]
        public virtual IActionResult DeleteById(Guid entityId)
        {
            try
            {
                var res = _baseService.DeleteById(entityId);
                if (res.IsValid == true)
                {
                    res.Messenger.devMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Success;
                    res.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Delete_Success;
                    res.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.Success;
                    return StatusCode(res.StatusCode, res);
                }
                else
                {
                    res.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.BadRequest;
                    return StatusCode(res.StatusCode, res);
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }
        #endregion
    }
}
