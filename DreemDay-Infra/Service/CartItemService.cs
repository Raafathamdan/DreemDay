using DreemDay_Core.DTOs.CartItemDTOs;
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
        public Task CreateCartItem(CreateCartItemDto createCartItemDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItemCardDto>> GetAllCartItem()
        {
            throw new NotImplementedException();
        }

        public Task<CartItemById> GetCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItem(UpdateCartItemDto updateCartItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
