using DreemDay_Core.DTOs.CartItemDTOs;
using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using DreemDay_Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepos _repos;
        private readonly IUserRepos _userRepos;
        private readonly ICartRepos _cart;

        public CartItemService(ICartItemRepos repos,IUserRepos userRepos, ICartRepos cart ) 
        {
            _repos = repos;
            _userRepos = userRepos;
            _cart = cart;
        }
    public async Task CreateCartItem(CreateCartItemDto createCartItemDto)
    {
      // Get the CartByIdDto
      var cartDto = await _cart.GetCart(createCartItemDto.CartId);

      Cart cart = null;

      // Map CartByIdDto to Cart if cartDto is not null
      if (cartDto != null)
      {
        cart = new Cart
        {
          Id = cartDto.Id,
          UserId = cartDto.UserId,
          IsActive = cartDto.IsActive,
         
        };
      }

      // Check if the cart is inactive or doesn't exist
      if (cart == null || !cart.IsActive)
      {
        // If the cart is inactive or doesn't exist, create a new cart
        cart = new Cart
        {
          UserId = createCartItemDto.UserId,
          IsActive = true,
          CreationDate = DateTime.Now
        };

        var newCartId = await _cart.CreateCart(cart);
        if (newCartId == 0)
        {
          throw new Exception("Failed To Create New Cart");
        }

        createCartItemDto.CartId = newCartId;
      }

      // Create the new cart item
      var cartItem = new CartItem
      {
        CreationDate = DateTime.Now,
        CartId = createCartItemDto.CartId,
        Quantity = createCartItemDto.Quantity,
        ServiceId = createCartItemDto.ServiceId
      };

      var id = await _repos.CreateCartItem(cartItem);
      if (id == 0)
      {
        throw new Exception("Failed To Create CartItem");
      }
    }



    public async Task DeleteCartItem(int id)
        {
            await _repos.DeleteCartItem(id);
        }

        public async Task<List<CartItemCardDto>> GetAllCartItem()
        {
            return await _repos.GetAllCartItem();
        }

        public async Task<CartItemById> GetCartItem(int id)
        {
            return await _repos.GetCartItem(id);
        }

    public async Task<List<CartItemById>> GetCartItemByUserId(int userId)
    {
      // Check if the user exists
      var user = await _userRepos.GetUser(userId);
      if (user == null)
        throw new Exception("User Does Not Exist");

      // Fetch cart items where the cart is active
      var cartItems = await _repos.GetAllCartItems();
      var userCartItems = cartItems
          .Where(c => c.userId == userId && c.CartActivate)
          .ToList();

      return userCartItems;
    }

    public async Task UpdateCartItem(UpdateCartItemDto updateCartItemDto)
        {
           await _repos.UpdateCartItem(updateCartItemDto);
        }
    }
}
