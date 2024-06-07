﻿using DreemDay_Core.DTOs.OrderDTOs;
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
        Task<OrderByIdDto> GetOrder(int id);
        Task<int> CreateOrder(CreateOrderDto createOrderDto);
        Task UpdateOrder(UpdateOrderDto updateOrderDto);
        Task DeleteOrder(int id);
    }
}
