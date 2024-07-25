using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IPaymentRepos
    {
        Task<List<PaymentCardDto>> GetAllPayments();
        Task<Payment> GetPayment(int id);
        Task<Payment> IsValidPayment(string code,string cardNumber , string cardHolder, float price);

        Task<int> CreatePayment(CreatePaymentDto createPaymentDto);
        Task UpdatePayment(UpdatePaymentDto updatePaymentDto);
        Task DeletePayment(int id);
    }
}
