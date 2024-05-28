using DreemDay_Core.DTOs.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface ICartRepos
    {
        Task<List<CartCardDto>> GetAllCart();
        Task<CartByIdDto> GetCart(int id);
        Task CreateCart(CreateCartDto createCartDto);
        Task UpdateCart(UpdateCartDto updateCartDto);
        Task DeleteCart(int id);
    }
}
