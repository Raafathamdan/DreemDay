using DreemDay_Core.Context;
using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Infra.Repository
{
    public class OrderRepos : IOrderRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public OrderRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateOrder(Order order)
        {
           
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateOrder Has been Finised Successfully");

            return order.Id;
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null) 
                return;
            Log.Information("Order Is Exists");
            order.IsDeleted = true;
            _dbContext.Update(order);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging Delete Order Has been Finised Successfully");


        }

        public async Task<List<OrderCardDto>> GetAllOrder()
        {
            var ord = await _dbContext.Orders
                .Where(x => !x.IsDeleted)
                .Join(_dbContext.Users,
                    o => o.UserId,
                    u => u.Id,
                    (o, u) => new { Order = o, User = u })
                .Join(_dbContext.Carts,
                    ou => ou.Order.CartId,
                    c => c.Id,
                    (ou, c) => new { OrderUser = ou, Cart = c })
                .Select(order => new OrderCardDto
                {
                    Id = order.OrderUser.Order.Id,
                    CartId = order.OrderUser.Order.CartId,
                    UserId = order.OrderUser.User.Id,
                    Status = order.OrderUser.Order.Status,
                    Date = order.OrderUser.Order.Date.ToString(),
                    Title = order.OrderUser.Order.Title
                }).ToListAsync();
            Log.Debug("Debugging GetAllOrder Has been Finised Successfully");
            return ord;
        }
        public async Task<OrderByIdDto> GetOrder(int id)
        {
            var order = await _dbContext.Orders
                .Join(_dbContext.Users,
                    o => o.UserId,
                    u => u.Id,
                    (o, u) => new { Order = o, User = u })
                .Join(_dbContext.Carts,
                    ou => ou.Order.CartId,
                    c => c.Id,
                    (ou, c) => new { OrderUser = ou, Cart = c })
                .Select(o => o.OrderUser.Order) 
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;
            Log.Information("Order Is Exists");
            var O = new OrderByIdDto
            {
                Id = order.Id,
                CartId = order.CartId,
                UserId = order.UserId,
                Status = order.Status,
                Date = order.Date.ToString(),
                Title = order.Title,
                CreationDate = order.CreationDate.ToString(),
                ModifiedDate = order.ModifiedDate.ToString(),
                IsDeleted = order.IsDeleted,
                Note = order.Note,
                PaymentMethod = order.PaymentMethod,
            };
            Log.Debug("Debugging GetOrder Has been Finised Successfully");
              return O;
        }


        public async Task UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            var order = await _dbContext.Orders.FindAsync(updateOrderDto.Id);
            if (order == null) 
                return;
            Log.Information("Order Is Exists");
            order.Note = updateOrderDto.Note;
            order.Title = updateOrderDto.Title;
            order.Status = updateOrderDto.Status;
            order.Date = updateOrderDto.Date;
            order.ModifiedDate= DateTime.Now;
            order.IsDeleted = updateOrderDto.IsDeleted;
            order.PaymentMethod = updateOrderDto.PaymentMethod;
            order.CartId = updateOrderDto.CartId;
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateOrder Has been Finised Successfully");


        }
    }
}
