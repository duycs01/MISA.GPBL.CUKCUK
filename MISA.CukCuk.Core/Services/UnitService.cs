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
    public class UnitService: BaseService<Unit>, IUnitService
    {
        #region DECLEAR
        IUnitRepository _unitRepository;
        #endregion

        #region Contructor

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreateBy duylv - 27/08/2021
        public UnitService(IUnitRepository unitRepository) : base(unitRepository)
        {
            _unitRepository = unitRepository;
        }
        #endregion
    }
}
