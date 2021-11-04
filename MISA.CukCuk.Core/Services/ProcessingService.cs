using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class ProcessingService :BaseService<Processing>, IProcessingService
    {
        #region DECLEAR
        IProcessingRepository _processingRepository;
        #endregion

        #region Contructor

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreateBy duylv - 27/08/2021
        public ProcessingService(IProcessingRepository processingRepository) : base(processingRepository)
        {
            _processingRepository = processingRepository;
        }
        #endregion
    }
}
