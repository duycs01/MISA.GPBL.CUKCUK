using Microsoft.Extensions.Configuration;
using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Infrastructure.Repositories
{
    public class ProcessingRepository:BaseRepository<Processing>, IProcessingRepository
    {
        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public ProcessingRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
