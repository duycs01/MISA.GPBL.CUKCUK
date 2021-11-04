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
    public class MenuGroupsController : BaseEntityController<MenuGroup>    
    {
        #region DECLEAR
        IMenuGroupService _menuGroupService;
        IMenuGroupRepository _menuGroupRepository;
        #endregion

        #region Contructor

        public MenuGroupsController(IMenuGroupService menuGroupService, IMenuGroupRepository menuGroupRepository) : base(menuGroupService, menuGroupRepository)
        {
            _menuGroupService = menuGroupService;
            _menuGroupRepository = menuGroupRepository;
        }
        #endregion
    }
}
