using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class BaseEntity
    {
        #region Property
        /// <summary>
        ///  Ngày tạo bản ghi
        ///  CreatedBy: duylv - 29/09/2021
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa bản ghi
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa bản ghi
        /// CreatedBy: duylv - 29/09/2021
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
