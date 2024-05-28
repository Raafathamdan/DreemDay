using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class OrderRepos : IOrderRepos
    {
        public Task CreateOrder(CreateOrderDto createOrderDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderCardDto>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<OrderByIdDto> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            throw new NotImplementedException();
        }
    }
}
