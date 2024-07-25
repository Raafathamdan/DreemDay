using DreemDay_Core.DTOs.CartItemDTOs;
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

        public CartItemService(ICartItemRepos repos,IUserRepos userRepos ) 
        {
            _repos = repos;
            _userRepos = userRepos;
        }
        public async Task CreateCartItem(CreateCartItemDto createCartItemDto)
        {

            var cartItem = new CartItem();
            cartItem.CreationDate = DateTime.Now;
            cartItem.CartId = createCartItemDto.CartId;
            cartItem.Quantity = createCartItemDto.Quantity;
            cartItem.ServiceId = createCartItemDto.ServiceId;
            await _repos.CreateCartItem(cartItem);
            var id = await _repos.CreateCartItem(cartItem);
            if (id == 0)
                throw new Exception("Failed To Create CartItem");
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

        public async Task UpdateCartItem(UpdateCartItemDto updateCartItemDto)
        {
           await _repos.UpdateCartItem(updateCartItemDto);
        }
    }
}
