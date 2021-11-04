using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class Unit: BaseEntity
    {
        public Guid UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }

    }
}
