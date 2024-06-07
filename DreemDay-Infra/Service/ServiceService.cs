using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepos _repos;
        public ServiceService(IServiceRepos repos)
        {
            _repos = repos;
        }

        public async Task<int> CreateService(CreateServiceDto createServiceDto)
        {
            return await _repos.CreateService(createServiceDto);
        }

        public async Task DeleteService(int id)
        {
            await _repos.DeleteService(id);
        }

        public async Task<List<ServiceCardDto>> GetAllService()
        {
            return await _repos.GetAllService();
        }

        public async Task<ServiceByIdDto> GetService(int id)
        {
            return await _repos.GetService(id);
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _repos.UpdateService(updateServiceDto);
        }
    }
}
