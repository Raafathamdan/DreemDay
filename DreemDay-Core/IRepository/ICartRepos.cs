using DreemDay_Core.DTOs.CartDTOs;
using DreemDay_Core.Models.Entity;
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
        Task<int> CreateCart(Cart cart);
        Task<int> GetCartIdByUser(int userId);
        Task UpdateCart(UpdateCartDto updateCartDto);
        Task UpdateCartActivation(CartByIdDto CartByIdDto);
        Task DeleteCart(int id);
    }
}
