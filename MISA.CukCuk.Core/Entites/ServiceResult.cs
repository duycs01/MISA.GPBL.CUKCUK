using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class ServiceResult : Message
    {
        #region Property

        /// <summary>
        /// Kiểm tra lỗi
        /// CreatedBy: duylv-29/09/2021
        /// </summary>
        public bool IsValid { get; set; } = true;

        /// <summary>
        /// Dữ liệu trả về
        /// CreatedBy: duylv-29/09/2021
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông báo
        /// CreatedBy: duylv-29/09/2021
        /// </summary>
        public Message Messenger { get; set; } = new Message();

        /// <summary>
        /// Trạng thái restful
        /// CreatedBy: duylv-29/09/2021
        /// </summary>
        public int StatusCode { get; set; }
        #endregion
    }

}
