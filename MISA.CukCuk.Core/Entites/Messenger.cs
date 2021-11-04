using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class Message
    {
        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string devMsg { get; set; }

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public string userMsg { get; set; }
    }
}
