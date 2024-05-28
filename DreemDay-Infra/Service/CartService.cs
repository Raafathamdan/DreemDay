using DreemDay_Core.DTOs.CartDTOs;
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
        public Task CreateCart(CreateCartDto createCartDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartCardDto>> GetAllCart()
        {
            throw new NotImplementedException();
        }

        public Task<CartByIdDto> GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCart(UpdateCartDto updateCartDto)
        {
            throw new NotImplementedException();
        }
    }
}
