using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class MenuGroup : BaseEntity
    {
        public Guid MenuGroupId { get; set; }
        public string MenuGroupCode { get; set; }
        public string MenuGroupName { get; set; }
        public string Description { get; set; }
    }
}
