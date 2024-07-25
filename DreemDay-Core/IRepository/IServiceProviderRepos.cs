using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IServiceProviderRepos
    {
        Task<List<ServiceProviderCardDto>> GetAllServiceProviders();
        Task<ServiceProviderByIdDto> GetServiceProvider(int id);
        Task<int> CreateServiceProvider(ServiceProvider serviceProvider);
        Task UpdateServiceProvider(UpdateServiceProviderDto updateServiceProviderDto);
        Task DeleteServiceProvider(int id);
    }
}
