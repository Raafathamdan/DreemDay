using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CartDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        public async Task<int> CreateCart(Cart cart)
        {
           
            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateCart Has been Finised Successfully");

            return cart.Id;

        }

        public async Task DeleteCart(int id)
        {
            var cart = await _dbContext.Carts.FindAsync(id);
            if (cart == null) 
            return;
            Log.Information("cart Is Exists");

            cart.IsDeleted = true;
            _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging DeleteCart Has been Finised Successfully");

        }

        public async Task<List<CartCardDto>> GetAllCart()
        {
            var carts =  await _dbContext.Carts
                .Where(x => x.IsDeleted==false)
                .Join(_dbContext.Users, c => c.UserId, u => u.Id, (c, u) => new {Cart=c,User=u})
                .Select( cart => new CartCardDto
                {
                    Id = cart.Cart.Id,
                    UserId = cart.User.Id
                }).ToListAsync();
                Log.Debug("Debugging GetAllCart Has been Finised Successfully");
                return carts;
        }

        public async Task<CartByIdDto> GetCart(int id)
        {
            var cart = await _dbContext.Carts
                .Join(_dbContext.Users,
                    c => c.UserId,
                    u => u.Id,
                    (c, u) => new { Cart = c, User = u })
                .FirstOrDefaultAsync(x => x.Cart.Id == id);

            if (cart == null) 
                return null;
            Log.Information("cart Is Exists");


            var c =  new CartByIdDto
                    {
                       Id=cart.Cart.Id,
                       UserId = cart.User.Id,
                       IsActive = cart.Cart.IsActive,
                       CreationDate = cart.Cart.CreationDate.ToString(),
                       ModifiedDate = cart.Cart.ModifiedDate.ToString(),
                       IsDeleted = cart.Cart.IsDeleted??false
                
                    };
            Log.Debug("Debugging GetCart Has been Finised Successfully");
                return c;
        }

        public async Task UpdateCart(UpdateCartDto updateCartDto)
        {
            var cart = await _dbContext.Carts.FindAsync(updateCartDto.Id);
            if (cart == null) return;
            Log.Information("cart Is Exists");
            cart.IsActive = updateCartDto.IsActive;
            cart.IsDeleted = updateCartDto.IsDeleted;
            cart.ModifiedDate = DateTime.Now;
            _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateCart Has been Finised Successfully");

        }

    public async Task UpdateCartActivation(CartByIdDto CartByIdDto)
    {
      var cart = await _dbContext.Carts.FindAsync(CartByIdDto.Id);
      if (cart == null) return;
      cart.IsActive = false;
      await _dbContext.SaveChangesAsync();
      Log.Debug("Debugging Cart has been deactivated Successfully");

    }
  }
}
