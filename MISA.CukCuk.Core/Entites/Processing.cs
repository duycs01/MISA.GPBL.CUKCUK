using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class Processing:BaseEntity
    {
        public Guid ProcessingId { get; set; }
        public string ProcessingCode { get; set; }
        public string ProcessingName { get; set; }
    }
}
