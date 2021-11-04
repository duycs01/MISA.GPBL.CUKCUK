using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class ServiceHobbyService : BaseService<ServiceHobby>, IServiceHobbyService
    {
        #region DECLEAR
        IServiceHobbyRepository _serviceHobbyRepository;
        #endregion

        #region Contructor

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreateBy duylv - 27/08/2021
        public ServiceHobbyService(IServiceHobbyRepository serviceHobbyRepository) : base(serviceHobbyRepository)
        {
            _serviceHobbyRepository = serviceHobbyRepository;
        }
        #endregion
        #region Method
        /// <summary>
        /// Lấy sở thích theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        public ServiceResult GetServiceHobbyPaging(string filterName, int pageSize, int pageIndex)
        {
            var res = _serviceHobbyRepository.GetServiceHobbyPaging(filterName, pageSize, pageIndex);

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
                _serviceResult.StatusCode = (int)Enum.StatusCode.NoContent;
                _serviceResult.Data = res;

            }
            return _serviceResult;
        }
        #endregion
    }
}
