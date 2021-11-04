using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class InputPaging
    {
        public string Column { get; set; }
        public string Operator { get; set; }
        public dynamic FilterName { get; set; }

    }
}
