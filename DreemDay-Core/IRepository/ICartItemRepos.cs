using DreemDay_Core.DTOs.CartItemDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface ICartItemRepos
    {
        Task<List<CartItemCardDto>> GetAllCartItem();
        Task<CartItemById> GetCartItem(int id);
        Task<int> CreateCartItem(CartItem item);
        Task UpdateCartItem(UpdateCartItemDto updateCartItemDto);
        Task DeleteCartItem(int id);
    }
}
