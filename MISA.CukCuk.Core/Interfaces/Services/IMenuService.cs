using MISA.CukCuk.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Services
{
    public interface IMenuService : IBaseService<Menu>
    {


        /// <summary>
        /// Kiểm tra trùng mã thực đơn
        /// </summary>
        /// <param name="menuId">Id thực đơn</param>
        /// <param name="menuCode">Mã thực đơn</param>
        /// <returns>True là trùng false là không trùng</returns>
        /// CreatedBy: duylv-30/09/2021
        ServiceResult CheckDuplicateMenuCode(Guid? menuId, string menuCode);

        
        /// <summary>
        /// Lấy mã thực đơn mới
        /// </summary>
        /// <param name="menuId">Id thực đơn</param>
        /// <param name="menuCode">Mã thực đơn</param>
        /// <returns>True là trùng false là không trùng</returns>
        /// CreatedBy: duylv-30/09/2021
        ServiceResult GetNewMenuCode(string menuCode);

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="menuPaging"></param>
        /// CreatedBy: duylv-30/09/2021
        ServiceResult GetMenuPaging(List<InputPaging> listInputPaging, int pageSize,int pageIndex);

    }
}
