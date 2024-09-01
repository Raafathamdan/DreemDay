using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CartItemDTOs;
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

    public async Task<int> CreateCartItem(CartItem item)
    {
      _dbContext.CartItems.Add(item);
      await _dbContext.SaveChangesAsync();
      Log.Debug("Debugging CreateCartItem Has been Finised Successfully");

      return item.Id;

    }

    public async Task DeleteCartItem(int id)
    {
      var cartitem = await _dbContext.CartItems.FindAsync(id);
      if (cartitem == null) return;
      Log.Information("cartitem Is Exists");
      cartitem.IsDeleted = true;
      _dbContext.CartItems.Update(cartitem);
      await _dbContext.SaveChangesAsync();
      Log.Debug("Debugging DeleteCartItem Has been Finised Successfully");


    }


    public async Task<CartItemById> GetCartItem(int id)
    {
      var cartItem = await _dbContext.CartItems
                  .Join(_dbContext.Carts, ci => ci.CartId, c => c.Id, (ci, c) => new { CartItem = ci, Cart = c })
                  .Join(_dbContext.Services, ci => ci.CartItem.ServiceId, s => s.Id, (ci, s) => new { ci.CartItem, ci.Cart, Service = s })
                  .FirstOrDefaultAsync(ci => ci.CartItem.Id == id);

      if (cartItem == null)
        return null;
      Log.Information("cartitem Is Exists");
      return new CartItemById
      {
        Id = cartItem.CartItem.Id,
        CartId = cartItem.CartItem.CartId,
        ServiceId = cartItem.CartItem.ServiceId,
        userId = cartItem.Cart.UserId,
        ServiceImage= $"https://localhost:44324/Images/{cartItem.Service.Image}",
        ServiceName = cartItem.Service.Name,
        ServiceDescription = cartItem.Service.Description,
        Quantity = cartItem.CartItem.Quantity,
        CreationDate = cartItem.CartItem.CreationDate.ToString(),
        ModifiedDate = cartItem.CartItem.ModifiedDate.ToString(),
        IsDeleted = cartItem.CartItem.IsDeleted ?? false

      };

    }

    public async Task UpdateCartItem(UpdateCartItemDto updateCartItemDto)
    {
      var cartitem = await _dbContext.CartItems.FindAsync(updateCartItemDto.Id);
      if (cartitem == null)
        return;
      Log.Information("cartitem Is Exists");
      cartitem.Quantity = updateCartItemDto.Quantity;
      cartitem.ServiceId = updateCartItemDto.ServiceId;
      cartitem.CartId = updateCartItemDto.CartId;
      cartitem.ModifiedDate = DateTime.Now;
      cartitem.IsDeleted = updateCartItemDto.IsDeleted;
      _dbContext.CartItems.Update(cartitem);
      await _dbContext.SaveChangesAsync();
      Log.Debug("Debugging UpdateCartItem Has been Finised Successfully");

    }

    public async Task<List<CartItemCardDto>> GetAllCartItem()
    {
      return await _dbContext.CartItems
          .Where(x => x.IsDeleted == false)
          .Join(_dbContext.Carts, ci => ci.CartId, c => c.Id, (ci, c) => new { CartItem = ci, Cart = c })
          .Join(_dbContext.Services, temp => temp.CartItem.ServiceId, s => s.Id, (temp, s) => new { temp.CartItem, temp.Cart, Service = s })
          .Select(cartItem => new CartItemCardDto
          {
            CartId = cartItem.Cart.Id,
            ServiceId = cartItem.Service.Id,
            Id = cartItem.CartItem.Id,
            CartActivate= cartItem.Cart.IsActive

          }).ToListAsync();

    }

    public async Task<List<CartItemById>> GetAllCartItems()
    {
      var cartItems = await _dbContext.CartItems
                       .Join(_dbContext.Carts, ci => ci.CartId, c => c.Id, (ci, c) => new { CartItem = ci, Cart = c })
                       .Join(_dbContext.Services, ci => ci.CartItem.ServiceId, s => s.Id, (ci, s) => new { ci.CartItem, ci.Cart, Service = s })
                       .ToListAsync();

      if (cartItems == null || cartItems.Count == 0)
        return null;

      var result = cartItems.Select(ci => new CartItemById
      {
        Id = ci.CartItem.Id,
        CartId = ci.CartItem.CartId,
        CartActivate=ci.Cart.IsActive,
        ServiceId = ci.CartItem.ServiceId,
        userId = ci.Cart.UserId,
        ServiceImage= ci.Service.Image,
        ServiceDescription= ci.Service.Description,
        ServiceName= ci.Service.Name,
        Quantity = ci.CartItem.Quantity,
        CreationDate = ci.CartItem.CreationDate.ToString(),
        ModifiedDate = ci.CartItem.ModifiedDate.ToString(),
        IsDeleted = ci.CartItem.IsDeleted ?? false,
        Price=ci.Service.PriceAfterDiscount
        
      }).ToList();

      Log.Information("Cart items exist");
      return result;
    }
  }
}
