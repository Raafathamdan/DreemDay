using DreemDay_Core.DTOs.CartDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
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
        private readonly IUserRepos _userRepos;
        public CartService(ICartRepos repos, IUserRepos userRepos)
        {
            _repos = repos;
            _userRepos = userRepos;
        }
        public async Task CreateCart(CreateCartDto createCartDto)
        {
            var user = await _userRepos.GetUser(createCartDto.UserId);
            if (user != null) 
            {
                var cart = new Cart();

                cart.UserId = createCartDto.UserId;
                cart.CreationDate = DateTime.Now;
                cart.IsActive = true;
                await _repos.CreateCart(cart);
                var id = await _repos.CreateCart(cart);
                if (id == 0)
                    throw new Exception("Failed To Create Cart");
            }
            throw new Exception("User Dose not Exisit");



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
