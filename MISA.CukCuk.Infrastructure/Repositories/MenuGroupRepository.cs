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
    public class MenuGroupRepository:BaseRepository<MenuGroup>, IMenuGroupRepository
    {
        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        public MenuGroupRepository(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion
    }
}
