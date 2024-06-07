using DreemDay_Core.DTOs.ServiceProviderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IServiceProviderService
    {
        Task<List<ServiceProviderCardDto>> GetAllServiceProviders();
        Task<ServiceProviderByIdDto> GetServiceProvider(int id);
        Task<int> CreateServiceProvider(CreateServiceProviderDto createServiceProviderDto);
        Task UpdateServiceProvider(UpdateServiceProviderDto updateServiceProviderDto);
        Task DeleteServiceProvider(int id);
    }
}
