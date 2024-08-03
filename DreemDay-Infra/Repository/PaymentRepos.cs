using DreemDay_Core.Context;
using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<int> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = new Payment
            {
                CardNumber = createPaymentDto.CardNumber,
                CardHolder = createPaymentDto.CardHolder,
                Balance = createPaymentDto.Balance,
                Code = createPaymentDto.Code,
                ExpireDate = createPaymentDto.ExpireDate
            };

            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();

            return payment.Id;
        }

        public async Task DeletePayment(int id)
        {
            var payment = await _dbContext.Payments.FindAsync(id);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PaymentCardDto>> GetAllPayments()
        {
            return await _dbContext.Payments
                .Select(payment => new PaymentCardDto
                {
                    Id = payment.Id,
                    CardNumber = payment.CardNumber,
                    Balance = payment.Balance,
                    ExpireDate = payment.ExpireDate
                }).ToListAsync();
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }

        public async Task<Payment> IsValidPayment(string code, string cardNumber, string cardHolder, float price)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(
                x => x.Balance >= price &&
                     x.CardHolder == cardHolder &&
                     x.CardNumber == cardNumber &&
                     x.Code == code);
        }

        public async Task UpdatePayment(UpdatePaymentDto updatePaymentDto)
        {
            var payment = await _dbContext.Payments.FindAsync(updatePaymentDto.Id);
            if (payment != null)
            {
                payment.CardNumber = updatePaymentDto.CardNumber;
                payment.CardHolder = updatePaymentDto.CardHolder;
                payment.Balance = updatePaymentDto.Balance;
                payment.Code = updatePaymentDto.Code;
                payment.ExpireDate = updatePaymentDto.ExpireDate;

                _dbContext.Payments.Update(payment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
