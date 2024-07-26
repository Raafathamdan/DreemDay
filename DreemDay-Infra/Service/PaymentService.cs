using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepos _repos;

        public PaymentService(IPaymentRepos repos)
        {
            _repos = repos;
        }

        public Task CreatePayment(CreatePaymentDto createPaymentDto)
        {
            return _repos.CreatePayment(createPaymentDto);
        }

        public async Task DeletePayment(int id)
        {
            await _repos.DeletePayment(id);
        }

        public async Task<List<PaymentCardDto>> GetAllPayments()
        {
            return await _repos.GetAllPayments();
        }

        public async Task<Payment> GetPayments(int id)
        {
            return await _repos.GetPayment(id);
        }

        public async Task UpdatePayment(UpdatePaymentDto updatePaymentDto)
        {
            await _repos.UpdatePayment(updatePaymentDto);
        }
    }
}
