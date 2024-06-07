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
