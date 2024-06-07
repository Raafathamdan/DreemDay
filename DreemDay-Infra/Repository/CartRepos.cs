using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CartDTOs;
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
    public class CartRepos : ICartRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public CartRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateCart(CreateCartDto createCartDto)
        {
            var cart = new Cart
            {
                UserId = createCartDto.UserId,
                CreationDate = DateTime.Now,
                IsActive = true

            };
            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();
            return cart.Id;

        }

        public async Task DeleteCart(int id)
        {
            var cart = await _dbContext.Carts.FindAsync(id);
            if (cart == null) return;
            cart.IsDeleted = true;
            cart.IsActive = false;
            _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CartCardDto>> GetAllCart()
        {
            return await _dbContext.Carts
                .Where(x => !x.IsDeleted)
                .Join(_dbContext.Users, c => c.UserId, u => u.Id, (c, u) => new {Cart=c,User=u})
                .Select( cart => new CartCardDto
                {
                    Id = cart.Cart.Id,
                    UserId = cart.User.Id
                })
                .ToListAsync();
        }

        public async Task<CartByIdDto> GetCart(int id)
        {
            var cart = await _dbContext.Carts
                .Join(_dbContext.Users,
                    c => c.UserId,
                    u => u.Id,
                    (c, u) => new { Cart = c, User = u })
                .FirstOrDefaultAsync(x => x.Cart.Id == id);

            if (cart == null) return null;

            return new CartByIdDto
            {
                UserId = cart.User.Id,
                IsActive = cart.Cart.IsActive,
                CreationDate = cart.Cart.CreationDate.ToString(),
                ModifiedDate = cart.Cart.ModifiedDate.ToString(),
                IsDeleted = cart.Cart.IsDeleted
                
            };
        }

        public async Task UpdateCart(UpdateCartDto updateCartDto)
        {
            var cart = await _dbContext.Carts.FindAsync(updateCartDto.Id);
            if (cart == null) return;
            cart.IsActive = updateCartDto.IsActive;
            cart.IsDeleted = updateCartDto.IsDeleted;
            cart.ModifiedDate = DateTime.Now;
            cart.UserId = updateCartDto.UserId;
            _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync();
        }
    }
}
