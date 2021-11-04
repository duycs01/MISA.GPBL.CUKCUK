using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repositories
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy tất bản ghi
        /// </summary>
        /// <returns>Trả ra danh sách bản ghi</returns>
        /// CreatedBy: duylv-29/09/2021
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin bản ghi theo entityId
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Trả ra thông tin bản ghi</returns>
        /// CreatedBy: duylv-29/09/2021
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm thông tin bản ghi
        /// </summary>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Trả ra số lượng bản ghi được thêm</returns>
        /// CreatedBy: duylv-29/09/2021
        int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Trả ra số lượng bản ghi được sửa</returns>
        /// CreatedBy: duylv-29/09/2021
        int Update(MISAEntity entity);

        /// <summary>
        /// Xóa thông tin bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>Trả ra số lượng bản ghi được xóa</returns>
        /// CreatedBy: duylv-29/09/2021
        int DeleteById(Guid entityId);
    }
}
