using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CartItemDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{

    public class CartItemRepos : ICartItemRepos
    {
        private readonly DreemDayDbContext _dbContext;
        private readonly ICartRepos _CartRepos;
        private readonly IServiceRepos _serviceRepos;
        
        public CartItemRepos(DreemDayDbContext dbContext,
            ICartRepos cartRepos, IServiceRepos serviceRepos)
        {
            _dbContext = dbContext;
            _CartRepos = cartRepos;
            _serviceRepos = serviceRepos;
        }

        public async Task<int> CreateCartItem(CreateCartItemDto createCartItemDto)
        {

          
            var cartitem = new CartItem
            {
                CreationDate = DateTime.Now,
                CartId = createCartItemDto.CartId,
                Quantity = createCartItemDto.Quantity,
                ServiceId = createCartItemDto.ServiceId,
            };
            _dbContext.CartItems.Add(cartitem);
            await _dbContext.SaveChangesAsync();
            return cartitem.Id;

        }

        public async Task DeleteCartItem(int id)
        {
            var cartitem= await _dbContext.CartItems.FindAsync(id);
            if (cartitem == null) return;
            cartitem.IsDeleted = true;
            _dbContext.CartItems.Update(cartitem);
            await _dbContext.SaveChangesAsync();

        }


        public async Task<CartItemById> GetCartItem(int id)
        {
            var cartItem = await _dbContext.CartItems
                        .Join(_dbContext.Carts, ci => ci.CartId, c => c.Id, (ci, c) => new { CartItem = ci, Cart = c })
                        .Join(_dbContext.Services, ci => ci.CartItem.ServiceId, s => s.Id, (ci, s) => new { ci.CartItem, ci.Cart, Service = s })
                        .FirstOrDefaultAsync(ci => ci.CartItem.Id == id);

            if (cartItem == null)
                return null;

            return new CartItemById
            {
                Id = cartItem.CartItem.Id,
                CartId = cartItem.CartItem.CartId,
                ServiceId = cartItem.CartItem.ServiceId,
                Quantity = cartItem.CartItem.Quantity,
                CreationDate = cartItem.CartItem.CreationDate.ToString(),
                ModifiedDate = cartItem.CartItem.ModifiedDate.ToString(),
                IsDeleted = cartItem.CartItem.IsDeleted
            };
        }

        public async Task UpdateCartItem(UpdateCartItemDto updateCartItemDto)
        {
            var cartitem = await _dbContext.CartItems.FindAsync(updateCartItemDto.Id);
            if (cartitem == null) return;
            cartitem.Quantity = updateCartItemDto.Quantity;
            cartitem.ServiceId = updateCartItemDto.ServiceId;
            cartitem.CartId = updateCartItemDto.CartId;
            cartitem.ModifiedDate=DateTime.Now;
            cartitem.IsDeleted = updateCartItemDto.IsDeleted;
            _dbContext.CartItems.Update(cartitem);
            await _dbContext.SaveChangesAsync();
            

        }

        public async Task<List<CartItemCardDto>> GetAllCartItem()
        {
            return await _dbContext.CartItems
                .Where(x => !x.IsDeleted)
                .Join(_dbContext.Carts, ci => ci.CartId, c => c.Id, (ci, c) => new { CartItem = ci, Cart = c })
                .Join(_dbContext.Services, temp => temp.CartItem.ServiceId, s => s.Id, (temp, s) => new { temp.CartItem, temp.Cart, Service = s })
                .Select(cartItem => new CartItemCardDto
                {
                    CartId = cartItem.Cart.Id,
                    ServiceId = cartItem.Service.Id,
                    Id = cartItem.CartItem.Id
                
                })
                .ToListAsync();
        }

    }
}
