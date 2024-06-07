using DreemDay_Core.DTOs.CartItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface ICartItemService
    {
        Task<List<CartItemCardDto>> GetAllCartItem();
        Task<CartItemById> GetCartItem(int id);
        Task<int> CreateCartItem (CreateCartItemDto createCartItemDto);
        Task UpdateCartItem (UpdateCartItemDto updateCartItemDto);
        Task DeleteCartItem (int id);

    }
}
