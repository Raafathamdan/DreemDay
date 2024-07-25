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
        private readonly IServiceProviderRepos _providerRepos;
        public ServiceService(IServiceRepos repos, IServiceProviderRepos providerRepos)
        {
            _repos = repos;
            _providerRepos = providerRepos;
        }

        public async Task CreateService(CreateServiceDto createServiceDto)
        {
            var serviceP = await _providerRepos.GetServiceProvider(createServiceDto.ServiceProviderId);
            if (serviceP != null)
            {
                var service = new DreemDay_Core.Models.Entity.Service();

                service.ServiceProviderId = serviceP.Id;
                service.Name = createServiceDto.Name;
                service.Description = createServiceDto.Description;
                service.Image = createServiceDto.Image;
                service.Price = createServiceDto.Price;
                service.Unit = createServiceDto.Unit;
                service.MinAmount = createServiceDto.MinAmount;
                service.MaxAmount = createServiceDto.MaxAmount;
                service.isHaveDiscount = createServiceDto.isHaveDiscount;
                service.DiscountAmount = createServiceDto.DiscountAmount;
                service.PriceAfterDiscount = createServiceDto.PriceAfterDiscount;
                service.CreationDate = DateTime.Now;

                await _repos.CreateService(service);
                var id = await _repos.CreateService(service);
                if (id == 0 )
                    throw new Exception("Failed To Create Service ");
            }
            throw new Exception("Service Provider Dose Not Exisit");

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
