using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entites;
using MISA.CukCuk.Core.Interfaces.Repositories;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.CukCuk.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenusController : BaseEntityController<Menu>
    {
        #region DECLEAR
        IMenuService _menuService;
        IMenuRepository _menuRepository;
        #endregion

        #region Contructor

        public MenusController(IMenuService menuService, IMenuRepository menuRepository) : base(menuService, menuRepository)
        {
            _menuService = menuService;
            _menuRepository = menuRepository;
        }
        #endregion

        #region Method
        /// <summary>
        /// Kiểm tra trùng mã thực đơn
        /// </summary>
        /// CreatedBy: duylv-30/09/2021
        [HttpPost("CheckDuplicateMenuCode")]
        public IActionResult CheckDuplicateMenuCode([FromBody] Menu menu)
        {
            try
            {
                var res = _menuService.CheckDuplicateMenuCode(menu.MenuId, menu.MenuCode);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Lấy mã thực đơn mới
        /// </summary>
        /// <menu name="menuName">Tên thực đơn</menu>
        /// CreatedBy: duylv-30/09/2021
        [HttpGet("GetNewMenuCode")]
        public IActionResult GetNewMenuCode([FromQuery] string menuName)
        {
            try
            {
                var res = _menuService.GetNewMenuCode(menuName);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Lấy thực đơn theo phân trang và lọc
        /// </summary>
        /// CreatedBy: duylv-30/09/2021
        [HttpPost("GetMenuPaging")]
        public IActionResult GetMenuPaging([FromBody] List<InputPaging> listInputPaging,[FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            try
            {
                var res = _menuService.GetMenuPaging(listInputPaging, pageSize, pageIndex);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <returns>Trả về số hàng được thêm vào</returns>
        /// Created by: duylv 29/09/2021
        public override IActionResult Insert([FromBody] Menu menu)
        {
            try
            {
                //if (menu.Avatar != null || menu.Avatar != "" || menu.Avatar != string.Empty)
                //{

                //    var strFirst = menu.Avatar.IndexOf("/");
                //    var strLast = menu.Avatar.IndexOf(";");

                //    var imageType = menu.Avatar.Substring(strFirst, strLast - strFirst);
                //    //xóa tên data đằng trước giữ lại base64
                //    string result = Regex.Replace(menu.Avatar, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);

                //    //convert base64 ra kiểu byte
                //    var bytes = Convert.FromBase64String(result);

                //    //đường dẫn lưu file
                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\imageMenu");

                //    //hàm lưu file
                //    using (var imageFile = new FileStream(filePath, FileMode.Create))
                //    {
                //        imageFile.Write(bytes, 0, bytes.Length);
                //        imageFile.Flush();
                //    }

                //    var id = Guid.NewGuid();
                //    menu.Avatar = id + "." + imageType;
                //}

                menu.MenuId = Guid.NewGuid();
                var res = _menuService.Insert(menu);
                
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }


        }


        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <returns>Trả về số hàng được thêm vào</returns>
        /// Created by: duylv 29/09/2021
        public override IActionResult Update(Guid entityId, [FromBody] Menu menu)
        {
            try
            {
                //if (menu.Avatar != null || menu.Avatar != "")
                //{
                //    var strfirst = menu.Avatar.IndexOf("/");
                //    var strlast = menu.Avatar.IndexOf(";");

                //    var imagetype = menu.Avatar.Substring(strfirst + 1, strlast - strfirst - 1);
                //    var id = Guid.NewGuid();
                //    //xóa tên data đằng trước giữ lại base64
                //    string result = Regex.Replace(menu.Avatar, @"^data:image\/[a-za-z]+;base64,", string.Empty);

                //    //convert base64 ra kiểu byte
                //    var bytes = Convert.FromBase64String(result);

                //    //đường dẫn lưu file
                //    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\imagemenu", id + "." + imagetype);
                //    //hàm lưu file
                //    using (var imagefile = new FileStream(filepath, FileMode.Create))
                //    {
                //        imagefile.Write(bytes, 0, bytes.Length);
                //        imagefile.Flush();
                //    }
                //    menu.Avatar = id + "." + imagetype;

                //}

                var res = _menuService.Update(entityId, menu);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <returns>Trả về số hàng được xóa</returns>
        /// Created by: duylv 05/10/2021
        public override IActionResult DeleteById(Guid entityId)
        {
            try
            {

                var res = _menuService.DeleteById(entityId);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);

            }
        }

        /// <summary>
        /// Lấy chi tiết bản ghi
        /// </summary>
        /// <returns>Trả về chi tiết bản ghi</returns>
        /// Created by: duylv 05/10/2021
        public override IActionResult GetById(Guid id)
        {
            try
            {
                var res = _menuService.GetById(id);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                _serviceResult.Messenger.devMsg = ex.Message;
                _serviceResult.Messenger.userMsg = MISA.CukCuk.Core.Resources.Resource.Exception_ErrorMsg;
                _serviceResult.IsValid = false;
                _serviceResult.StatusCode = (int)MISA.CukCuk.Core.Enum.StatusCode.ServerError;
                return StatusCode(_serviceResult.StatusCode, _serviceResult);
            }
        }
        #endregion

    }
}
