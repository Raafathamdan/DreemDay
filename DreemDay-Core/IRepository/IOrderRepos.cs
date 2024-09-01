using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IOrderRepos
    {
        Task<List<OrderCardDto>> GetAllOrder();
        Task<List<Order>> GetAllUserOrder();
        Task CancelOrder(int id);
        Task<OrderByIdDto> GetOrder(int id);
        Task<OrderByIdDto> GetOrderByCartId(int cartId);
        Task<int> CreateOrder(Order order);
        Task UpdateOrder(UpdateOrderDto updateOrderDto );
        Task DeleteOrder(int id);
    }
}
