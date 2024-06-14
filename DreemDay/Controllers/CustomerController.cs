using DreemDay_Core.DTOs.CartItemDTOs;
using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.DTOs.WishListDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Region;
using System.Diagnostics.Eventing.Reader;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IWishListService _wishListService;
        private readonly ICategoryService _categoryService;
        public CustomerController
            (
            ICartItemService cartItemService,
            IOrderService orderService,
            IUserService userService,
            IWishListService wishListService,
            ICategoryService categoryService
            )
        {
            _cartItemService = cartItemService;
            _orderService = orderService;
            _userService = userService;
            _wishListService = wishListService;
            _categoryService = categoryService;
        }
        #region User
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetUserById
        ///    {
        ///       "id":"Enter The User Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific User by ID.
        /// </summary>
        /// <returns>GetUserById</returns>
        /// <response code="201">Returns  GetUserById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute]int id)
        {
            if (id == 0)
            {
                return NotFound("User Does Not Exist");
            }
            else
            {
                try
                {
                    await _userService.GetUser(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateUser
        ///    {
        ///        "Id":"Enter The User Id Here ",
        ///        "FirstName": "Enter Your new User FirstName  Here",   
        ///        "LastName": "Enter Your new User LastName  Here",   
        ///        "Phone": "Enter Your new User Phone Here",   
        ///        "Email": "Enter Your new User Email Here",   
        ///        "BirthDate": "Enter Your new User BirthDate Here", 
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing User. 
        /// </summary>
        /// <returns>  User Has Been Updated  </returns>
        /// <response code="201"> Returns  User Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound();
            }
            else if (dto == null) 
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _userService.UpdateUser(dto);
                    return Ok("User Has Been Updated");

                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        #endregion
        #region Order
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetOrderById
        ///    {
        ///       "id":"Enter The Order Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific Order by ID.
        /// </summary>
        /// <returns>GetOrderById</returns>
        /// <response code="201">Returns  GetOrderById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Order Dose Not Exist");
            }
            else
            {
                try
                {
                    await _orderService.GetOrder(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateOrder
        ///     {          
        ///       "Note": "Enter Your new Order Note  Here",   
        ///       "Title": "Enter Your new Customer Title Here",   
        ///       "CartId": "Enter Your new Customer CartId Here",   
        ///       "UserId": "Enter Your new Customer UserId Here",   
        ///       "PaymentMethod": "Enter Your new Customer PaymentMethod Here",   
        ///       "OrderStatus": "Enter Your new Customer OrderStatus Here",   
        ///       "DateTime": "Enter Your new Customer DateTime Here",   
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New Order.
        /// </summary>
        /// <returns>A newly created Order</returns>
        /// <response code="201">Returns the newly created Order</response>
        /// <response code="400">If the error was occured</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _orderService.CreateOrder(dto);
                    return Ok("New Order Has Been Created");
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateOrder
        ///    {
        ///       "Id":"Enter The Order Id Here ",
        ///       "Note": "Enter Your new Order Note  Here",   
        ///       "Title": "Enter Your new Customer Title Here",   
        ///       "CartId": "Enter Your new Customer CartId Here",   
        ///       "UserId": "Enter Your new Customer UserId Here",   
        ///       "PaymentMethod": "Enter Your new Customer PaymentMethod Here",   
        ///       "OrderStatus": "Enter Your new Customer OrderStatus Here",   
        ///       "DateTime": "Enter Your new Customer DateTime Here",   
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing Order. 
        /// </summary>
        /// <returns>  Order Has Been Updated  </returns>
        /// <response code="201"> Returns  Order Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound();
            }
            else if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _orderService.UpdateOrder(dto);
                    return Ok("Order Has Been Updated");
                }
                catch( Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteOrder
        ///    {
        ///       "Id":"Enter The Order Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a Order
        /// </summary>
        /// <returns>A Order Has Been Deleted</returns>
        /// <response code="201">Returns  Order Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteOrder([FromRoute]int id)
        {
            if ( id == 0 )
            {
                return BadRequest("Order Dose Not Exist");
            }
            else
            {
                try
                {
                    await _orderService.DeleteOrder(id);
                    return Ok("Order Has Been Deleted");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        }

        #endregion
        #region CartItem
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetCartItemById
        ///    {
        ///       "id":"Enter The CartItem Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific CartItem by ID.
        /// </summary>
        /// <returns>GetCartItemById</returns>
        /// <response code="201">Returns  GetCartItemById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCartItemById([FromRoute]int id)
        {
            if (id  == 0 )
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _cartItemService.GetCartItem(id); 
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateCartItem
        ///     {          
        ///       "ServiceId": "Enter Your new CartItem ServiceId  Here",   
        ///       "CartId": "Enter Your new CartItem CartId Here",   
        ///       "Quantity": "Enter Your new CartItem Quantity Here",   
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New CartItem.
        /// </summary>
        /// <returns>A newly created CartItem</returns>
        /// <response code="201">Returns the newly created CartItem</response>
        /// <response code="400">If the error was occured</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCartItem([FromBody]CreateCartItemDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _cartItemService.CreateCartItem(dto);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateCartItem
        ///    {
        ///       "Id":"Enter The CartItem Id Here ",
        ///       "ServiceId": "Enter Your new CartItem ServiceId  Here",   
        ///       "CartId": "Enter Your new CartItem CartId Here",   
        ///       "Quantity": "Enter Your new CartItem Quantity Here",  
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing CartItem. 
        /// </summary>
        /// <returns>  CartItem Has Been Updated  </returns>
        /// <response code="201"> Returns  CartItem Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound();
            }
            else if (dto == null )
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _cartItemService.UpdateCartItem(dto);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        #endregion
        #region WishList
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetWishListById
        ///    {
        ///       "id":"Enter The WishList Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific WishList by ID.
        /// </summary>
        /// <returns>GetWishListById</returns>
        /// <response code="201">Returns  GetWishListById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetWishListById(int id)
        {
            if (id  == 0)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _wishListService.GetWishList(id);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateWishList
        ///     {          
        ///       "UserId": "Enter Your new WishList UserId  Here",   
        ///       "SerciceId": "Enter Your new WishList SerciceId Here",   
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New WishList.
        /// </summary>
        /// <returns>A newly created WishList</returns>
        /// <response code="201">Returns the newly created WishList</response>
        /// <response code="400">If the error was occured</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateWishList([FromBody] CreateWishListDto dto)
        {
            if (dto  == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _wishListService.CreateWishList(dto);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateWishList
        ///    {
        ///        "Id":"Enter The WishList Id Here ",
        ///        "UserId": "Enter Your new WishList UserId  Here",   
        ///        "SerciceId": "Enter Your new WishList SerciceId Here",   
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing WishList. 
        /// </summary>
        /// <returns>  WishList Has Been Updated  </returns>
        /// <response code="201"> Returns  WishList Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateWishList([FromBody] UpdateWishListDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound();
            }
            else if(dto ==  null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _wishListService.UpdateWishList(dto);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteWishList
        ///    {
        ///       "Id":"Enter The WishList Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a WishList
        /// </summary>
        /// <returns>A WishList Has Been Deleted</returns>
        /// <response code="201">Returns  WishList Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteWishList([FromRoute]int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _wishListService.DeleteWishList(Id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        #endregion
        #region Category
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetCategoryById
        ///    {
        ///       "id":"Enter The Category Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific Category by ID.
        /// </summary>
        /// <returns>GetCategoryById</returns>
        /// <response code="201">Returns  GetCategoryById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]int Id)
        {  if(Id == 0)
            {
                return NotFound("Category Does Not Exist");

            }
        else 
            {
                try
                {
                    await _categoryService.GetById(Id);
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
