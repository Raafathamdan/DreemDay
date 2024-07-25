using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IPaymentService
    {
        Task<List<PaymentCardDto>> GetAllPayments();
        Task<Payment> GetPayments(int id);
        Task CreatePayment (CreatePaymentDto createPaymentDto);
        Task UpdatePayment (UpdatePaymentDto updatePaymentDto);
        Task DeletePayment (int id);
    }
}
