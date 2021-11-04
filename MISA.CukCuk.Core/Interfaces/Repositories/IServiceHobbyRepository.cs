using MISA.CukCuk.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repositories
{
    public interface IServiceHobbyRepository : IBaseRepository<ServiceHobby>
    {
        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="inputPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        OutputPaging<ServiceHobby> GetServiceHobbyPaging(string filterName, int pageSize, int pageIndex);
    }
  
}
