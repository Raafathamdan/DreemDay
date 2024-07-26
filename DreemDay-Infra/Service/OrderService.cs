using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

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
            if (user == null)
                throw new Exception("User Does Not Exist");

            if (createOrderDto.PaymentMethod == PaymentMethod.Visa)
            {
                var payment = await _paymentRepos.IsValidPayment(createOrderDto.Code, createOrderDto.CardNumber, createOrderDto.CardHolder, createOrderDto.Price);
                if (payment == null)
                    throw new Exception("Invalid Payment Details");
            }

            var order = new Order
            {
                CartId = createOrderDto.CartId,
                UserId = user.Id,
                CreationDate = DateTime.Now,
                Title = createOrderDto.Title,
                Note = createOrderDto.Note,
                PaymentMethod = createOrderDto.PaymentMethod,
                Date = DateTime.Now,
                Status = OrderStatus.New
            };

            var id = await _repos.CreateOrder(order);
            if (id == 0)
                throw new Exception("Failed To Create Order");
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
