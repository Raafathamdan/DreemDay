using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepos _repos;
        public OrderService(IOrderRepos repos)
        {
            _repos = repos;
        }

        public async Task<int> CreateOrder(CreateOrderDto createOrderDto)
        {
            return await _repos.CreateOrder(createOrderDto);
        }

        public async Task DeleteOrder(int id)
        {
            await _repos.DeleteOrder(id);
        }

        public async Task<List<OrderCardDto>> GetAllOrder()
        {
            return await _repos.GetAllOrder();
        }

        public async Task<OrderByIdDto> GetOrder(int id)
        {
            return await _repos.GetOrder(id);
        }

        public async Task UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _repos.UpdateOrder(updateOrderDto);
        }
    }
}
