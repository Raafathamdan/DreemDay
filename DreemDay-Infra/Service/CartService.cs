using DreemDay_Core.DTOs.CartDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepos _repos;
        public CartService(ICartRepos repos)
        {
            _repos = repos;
        }
        public async Task<int> CreateCart(CreateCartDto createCartDto)
        {
            return await _repos.CreateCart(createCartDto);
        }

        public async Task DeleteCart(int id)
        {
            await _repos.DeleteCart(id);
        }

        public async Task<List<CartCardDto>> GetAllCart()
        {
            return await _repos.GetAllCart();
        }

        public async Task<CartByIdDto> GetCart(int id)
        {
            return await _repos.GetCart(id);
        }

        public async Task UpdateCart(UpdateCartDto updateCartDto)
        {
            await _repos.UpdateCart(updateCartDto);
        }
    }
}
