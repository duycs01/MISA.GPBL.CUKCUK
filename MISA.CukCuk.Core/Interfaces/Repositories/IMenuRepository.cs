using MISA.CukCuk.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repositories
{
    public interface IMenuRepository: IBaseRepository<Menu>
    {
        /// <summary>
        /// Kiểm tra trùng mã thực đơn
        /// </summary>
        /// <param name="menuId">Id thực đơn</param>
        /// <param name="menuCode">Mã thực đơn</param>
        /// <returns>True là trùng false là không trùng</returns>
        /// CreatedBy: duylv-30/09/2021
        bool CheckDuplicateMenuCode(Guid? menuId, string menuCode);

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// <param name="inputPaging"></param>
        /// CreatedBy: duylv-01/10/2021
        OutputPaging<Menu> GetMenuPaging(List<InputPaging> listInputPaging, int pageSize, int pageIndex);

        /// <summary>
        /// Thêm mới thực đơn
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        int InsertMenu(Menu menu);

        /// <summary>
        /// Sửa thực đơn
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        int UpdateMenu(Menu menu);

        /// <summary>
        /// lấy thực đơn theo id
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        Menu GetMenuById(Guid menuId);

        /// <summary>
        /// Xóa thực đơn
        /// </summary>
        /// CreatedBy: duylv-05/10/2021
        int DeleteMenu(Guid menuId);
    }
}
