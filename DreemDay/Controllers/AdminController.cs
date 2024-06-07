using DreemDay_Core.DTOs.CategoryDTOs;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _iuserService;
        private readonly IOrderService _iorderService;
        private readonly IServiceProviderService _iserviceProviderService;
        private readonly IServiceService _iserviceService;
        private readonly ICartItemService _icartItemService;
        private readonly ICartService _icartService;
        private readonly IWishListService _iwishListService;
        private readonly ICategoryService _icategoryService;

        public AdminController
            (IUserService iuserService,
            IOrderService iorderService,
            IServiceProviderService iserviceProviderService,
            IServiceService iserviceService,
            ICartItemService icartItemService,
            ICartService icartService,
            IWishListService iwishListService,
            ICategoryService icategoryService)
        {
            _iuserService = iuserService;
            _iorderService = iorderService;
            _iserviceProviderService = iserviceProviderService;
            _iserviceService = iserviceService;
            _icartItemService = icartItemService;
            _icartService = icartService;
            _iwishListService = iwishListService;
            _icategoryService = icategoryService;
        }


        #region User
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                await _iuserService.GetAllUsers();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound("User Does Not Exist");
            }
            else
            {
                try
                {
                    await _iuserService.DeleteUser(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion
        #region ServiceProvider
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllServiceProviders()
        {
            try
            {
                await _iserviceProviderService.GetAllServiceProviders();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteServiceProvider([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound("Service Provider Does Not Exist");
            }
            else
            {
                try
                {
                    await _iserviceProviderService.DeleteServiceProvider(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }
        #endregion
        #region Service
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                await _iserviceService.GetAllService();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region Order
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                await _iorderService.GetAllOrder();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region CartItem
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCartItems()
        {
            try
            {
                await _icartItemService.GetAllCartItem();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region Cart
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                await _icartService.GetAllCart();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region WishList
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllWishLists()
        {
            try
            {
                await _iwishListService.GetAllWishList();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region Category
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                await _icategoryService.GetAllCategories();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _icategoryService.CreateCategory(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound("Category Does Not Exist");
            }
            else if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _icategoryService.UpdateCategory(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (id  == 0) 
            {
                return NotFound("Category Does Not Exist");
            }
            else
            {
                try
                {
                    await _icategoryService.DeleteCategory(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion
    }
}
