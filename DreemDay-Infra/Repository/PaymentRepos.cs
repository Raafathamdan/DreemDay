using DreemDay_Core.Context;
using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.IRepository;
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

        public Task<PaymentByIdDto> GetPayments(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePayment(UpdatePaymentDto updatePaymentDto)
        {
            throw new NotImplementedException();
        }
    }
}
