using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DreemDay_Infra.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepos _repos;
        private readonly IUserRepos _userRepos;
        private readonly IPaymentRepos _paymentRepos;
        public OrderService(IOrderRepos repos, IUserRepos userRepos, IPaymentRepos paymentRepos)
        {
            _repos = repos;
            _userRepos = userRepos;
            _paymentRepos = paymentRepos;
        }

        public async Task CreateOrder(CreateOrderDto createOrderDto)
        {
            var user = await _userRepos.GetUser(createOrderDto.UserId);
            if (user != null) 
            {
                var order = new Order();

                order.CartId = createOrderDto.CartId;
                order.UserId = user.Id;
                order.CreationDate = DateTime.Now;
                order.Title = createOrderDto.Title;
                order.Note = createOrderDto.Note;
                order.PaymentMethod = createOrderDto.PaymentMethod;
                order.Date = DateTime.Now;
                order.Status = createOrderDto.Status;
                var id = await _repos.CreateOrder(order);
                if (id == 0)
                    throw new Exception("Failed To Create Order");

            }

            throw new Exception("User Dose Not Exisit");
            
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
