using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]

    [ApiController]
    public class ProcessingsController : BaseEntityController<Processing>
    {
        #region DECLEAR
        IProcessingService _processingService;
        IProcessingRepository _processingRepository;
        #endregion

        #region Contructor

        public ProcessingsController(IProcessingService processingService, IProcessingRepository processingRepository) : base(processingService, processingRepository)
        {
            _processingService = processingService;
            _processingRepository = processingRepository;
        }
        #endregion
    }
}
