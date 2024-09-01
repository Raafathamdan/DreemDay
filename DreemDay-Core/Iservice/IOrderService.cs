using DreemDay_Core.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.Iservice
{
    public interface IOrderService
    {
        Task<List<OrderCardDto>> GetAllOrder(); 
        Task<List<OrderByIdDto>> GetAllUserOrder(int id); 
        Task<OrderByIdDto> GetOrder(int id);
        Task CreateOrder(CreateOrderDto createOrderDto);
        Task UpdateOrder(UpdateOrderDto updateOrderDto);
        Task CancelOrder(int id);
        Task DeleteOrder(int id);
        
    }
}
