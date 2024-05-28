using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class ServiceProviderService : IServiceProviderService
    {
        public Task CreateServiceProvider(CreateServiceProviderDto createServiceProviderDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceProviderCardDto>> GetAllServiceProviders()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceProviderByIdDto> GetServiceProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceProvider(UpdateServiceProviderDto updateServiceProviderDto)
        {
            throw new NotImplementedException();
        }
    }
}
