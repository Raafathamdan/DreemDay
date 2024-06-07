using DreemDay_Core.DTOs.CartItemDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
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
        public CartItemService(ICartItemRepos repos) 
        {
            _repos = repos;
        }
        public async Task<int> CreateCartItem(CreateCartItemDto createCartItemDto)
        {
            return await _repos.CreateCartItem(createCartItemDto);
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
