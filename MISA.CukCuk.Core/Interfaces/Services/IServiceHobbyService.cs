using MISA.CukCuk.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    public interface IServiceHobbyService :IBaseService<ServiceHobby>
    {

        /// <summary>
        /// Lấy sở thích theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-30/09/2021
        ServiceResult GetServiceHobbyPaging(string filterName,int pageSize, int pageIndex);
    }
}
