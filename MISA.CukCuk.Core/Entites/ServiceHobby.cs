using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class ServiceHobby: BaseEntity
    {
        public Guid ServiceHobbyId { get; set; }
        public string ServiceHobbyName { get; set; }
        public int CollectMore { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

    }
}
