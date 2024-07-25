using DreemDay_Core.Context;
using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class PaymentRepos : IPaymentRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public PaymentRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentCardDto>> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetPayment(int id)
        {
           return await _dbContext.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payment> IsValidPayment(string code, string cardNumber, string cardHolder, float price)
        {
            var payment = await _dbContext.Payments.FirstOrDefaultAsync(
                x=>x.Balance>=price&&
                x.CardHolder.Equals(cardHolder)&&
                x.CardNumber.Equals(cardNumber)&&
                x.Code.Equals(code));
            return payment;
        }

        public Task UpdatePayment(UpdatePaymentDto updatePaymentDto)
        {
            throw new NotImplementedException();
        }
    }
}
