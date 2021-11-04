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
    public class ServiceHobbysController : BaseEntityController<ServiceHobby>
    {
        #region DECLEAR
        IServiceHobbyService _serviceHobbyService;
        IServiceHobbyRepository _serviceHobbyRepository;
        #endregion

        #region Contructor

        public ServiceHobbysController(IServiceHobbyService serviceHobbyService, IServiceHobbyRepository serviceHobbyRepository) : base(serviceHobbyService, serviceHobbyRepository)
        {
            _serviceHobbyService = serviceHobbyService;
            _serviceHobbyRepository = serviceHobbyRepository;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// CreatedBy: duylv-30/09/2021
        [HttpGet("GetServiceHobbyPaging")]
        public IActionResult GetServiceHobbyPaging([FromQuery] string filterName, [FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            try
            {
                var res = _serviceHobbyService.GetServiceHobbyPaging(filterName, pageSize, pageIndex);
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

        #endregion
    }
}
