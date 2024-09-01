using DreemDay_Core.DTOs.OrderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using DreemDay_Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        private ICartRepos _cart;

        public OrderService(IOrderRepos repos, IUserRepos userRepos, IPaymentRepos paymentRepos, ICartRepos cart)
        {
            _repos = repos;
            _userRepos = userRepos;
            _paymentRepos = paymentRepos;
            _cart = cart;
      
        }

    public async Task CancelOrder(int id)
    {
      await _repos.CancelOrder(id);
    }

    public async Task CreateOrder(CreateOrderDto createOrderDto)
    {
      try
      {
        // Retrieve the user
        var user = await _userRepos.GetUser(createOrderDto.UserId);
        if (user == null)
          throw new Exception("User Does Not Exist");

        // Validate payment if the payment method is Visa
        if (createOrderDto.PaymentMethod == PaymentMethod.Visa)
        {
          var payment = await _paymentRepos.IsValidPayment(createOrderDto.Code, createOrderDto.CardNumber, createOrderDto.CardHolder, createOrderDto.Price);
          if (payment == null)
            throw new Exception("Invalid Payment Details");
        }

        // Check if an order with the same CartId already exists
        var existingOrder = await _repos.GetOrderByCartId(createOrderDto.CartId);
        if (existingOrder != null)
        {
          throw new Exception("An order with this CartId already exists.");
        }

        // Create the order
        var order = new Order
        {
          CartId = createOrderDto.CartId,
          UserId = createOrderDto.UserId,
          CreationDate = DateTime.Now,
          Title = createOrderDto.Title,
          Note = createOrderDto.Note,
          PaymentMethod = createOrderDto.PaymentMethod,
          Date = DateTime.Now,
          Status = OrderStatus.New
        };

        // Save the order and get the generated ID
        var id = await _repos.CreateOrder(order);
        if (id == 0)
          throw new Exception("Failed To Create Order");

        // Update the cart's IsActive property to false
        var cart = await _cart.GetCart(createOrderDto.CartId); 
        if (cart == null)
          throw new Exception("Cart not found");

        cart.IsActive = false;
        await _cart.UpdateCartActivation(cart); 

        Log.Debug($"Order created with ID: {id}, and CartId: {createOrderDto.CartId} has been deactivated.");
      }
      catch (Exception ex)
      {
        Log.Error(ex, "Error creating order");
        throw new Exception("An error occurred while creating the order.", ex);
      }
    }




    public async Task DeleteOrder(int id)
        {
            await _repos.DeleteOrder(id);
        }

        public async Task<List<OrderCardDto>> GetAllOrder()
        {
            return await _repos.GetAllOrder();
        }

        public async Task<List<OrderByIdDto>> GetAllUserOrder(int id)
        {

         var user = await _userRepos.GetUser(id);
         if (user == null)
         throw new Exception("User Does Not Exist");

         var orders = await _repos.GetAllUserOrder();
         if (orders == null)
         return new List<OrderByIdDto>(); 

         var userOrders = orders
          .Where(order => order.UserId == id)
          .Select(order => new OrderByIdDto
          {
            Id = order.Id,
            UserId = order.UserId,
            CartId = order.CartId,
            Title = order.Title,
            Note = order.Note,
            PaymentMethod = order.PaymentMethod,
            Date = order.Date.ToString("yyyy-MM-dd"), 
            Status = order.Status,
            CreationDate = order.CreationDate.ToString("yyyy-MM-dd"), 
            ModifiedDate = order.ModifiedDate.HasValue ? order.ModifiedDate.Value.ToString("yyyy-MM-dd") : null,
            IsDeleted = order.IsDeleted?? false
          })
          .ToList();

         return userOrders;
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
