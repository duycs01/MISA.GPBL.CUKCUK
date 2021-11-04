using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entites
{
    public class OutputPaging<Entity>
    {

        public List<Entity> Data { get; set; }
        public int TotalRecord { get; set; }

        public int TotalPage { get; set; }  


    }
}
