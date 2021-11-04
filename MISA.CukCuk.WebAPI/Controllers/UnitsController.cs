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
    public class UnitsController : BaseEntityController<Unit>
    {
        #region DECLEAR
        IUnitService _unitService;
        IUnitRepository _unitRepository;
        #endregion

        #region Contructor

        public UnitsController(IUnitService unitService, IUnitRepository unitRepository) : base(unitService, unitRepository)
        {
            _unitService = unitService;
            _unitRepository = unitRepository;
        }
        #endregion
    }
}
