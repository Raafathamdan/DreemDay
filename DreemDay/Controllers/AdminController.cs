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
        /// <summary>
        ///  Retrieve a list of User.
        /// </summary>
        /// <returns>A List Of All User</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteUser
        ///    {
        ///       "Id":"Enter The User Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a User
        /// </summary>
        /// <returns>A User Has Been Deleted</returns>
        /// <response code="201">Returns  User Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of ServiceProviders.
        /// </summary>
        /// <returns>A List Of All ServiceProviders</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteServiceProvider
        ///    {
        ///       "Id":"Enter The ServiceProvider Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a ServiceProvider
        /// </summary>
        /// <returns>A ServiceProvider Has Been Deleted</returns>
        /// <response code="201">Returns  ServiceProvider Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of Service.
        /// </summary>
        /// <returns>A List Of All Service</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of Order.
        /// </summary>
        /// <returns>A List Of All Order</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of CartItem.
        /// </summary>
        /// <returns>A List Of All CartItem</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of Cart.
        /// </summary>
        /// <returns>A List Of All Cart</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of WishList.
        /// </summary>
        /// <returns>A List Of All WishList</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <summary>
        ///  Retrieve a list of Category.
        /// </summary>
        /// <returns>A List Of All Category</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
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
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateCategory
        ///     {          
        ///       "Title": "Enter Your new Category Title  Here",   
        ///       "Description": "Enter Your new Category Description Here",   
        ///         
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New Category.
        /// </summary>
        /// <returns>A newly created Category</returns>
        /// <response code="201">Returns the newly created Category</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateCategory
        ///    {
        ///        "Id":"Enter The Category Id Here ",
        ///        "Title": "Enter Your new Category Title  Here",   
        ///        "Description": "Enter Your new Category Description Here",
        ///        
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing Category. 
        /// </summary>
        /// <returns>  Category Has Been Updated  </returns>
        /// <response code="201"> Returns  Category Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteCategory
        ///    {
        ///       "Id":"Enter The Category Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a Category
        /// </summary>
        /// <returns>A Category Has Been Deleted</returns>
        /// <response code="201">Returns  Category Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
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
