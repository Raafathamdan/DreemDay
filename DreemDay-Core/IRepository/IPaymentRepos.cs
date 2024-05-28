using DreemDay_Core.DTOs.PaymentDTOs;
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
        Task<PaymentByIdDto> GetPayments(int id);
        Task CreatePayment(CreatePaymentDto createPaymentDto);
        Task UpdatePayment(UpdatePaymentDto updatePaymentDto);
        Task DeletePayment(int id);
    }
}
