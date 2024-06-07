using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.IRepository;
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
        private readonly IServiceProviderRepos _repos;
        public ServiceProviderService(IServiceProviderRepos repos)
        {
            _repos = repos;
        }
        public async Task<int> CreateServiceProvider(CreateServiceProviderDto createServiceProviderDto)
        {
            return await _repos.CreateServiceProvider(createServiceProviderDto);
        }

        public async Task DeleteServiceProvider(int id)
        {
            await _repos.DeleteServiceProvider(id);
        }

        public async Task<List<ServiceProviderCardDto>> GetAllServiceProviders()
        {
            return await _repos.GetAllServiceProviders();
        }

        public async Task<ServiceProviderByIdDto> GetServiceProvider(int id)
        {
            return await _repos.GetServiceProvider(id);
        }

        public async Task UpdateServiceProvider(UpdateServiceProviderDto updateServiceProviderDto)
        {
            await _repos.UpdateServiceProvider(updateServiceProviderDto);
        }
    }
}
