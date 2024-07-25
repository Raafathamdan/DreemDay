using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
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
        private readonly IUserRepos _userRepos;
        public ServiceProviderService(IServiceProviderRepos repos, IUserRepos userRepos)
        {
            _repos = repos;
            _userRepos = userRepos;
        }
        public async Task CreateServiceProvider(CreateServiceProviderDto createServiceProviderDto)
        {
            var user = await _userRepos.GetUser(createServiceProviderDto.UserId);
            if (user != null) 
            {
                var serviceb = new ServiceProvider();

                serviceb.Name = createServiceProviderDto.Name;
                serviceb.Email = createServiceProviderDto.Email;
                serviceb.Address = createServiceProviderDto.Address;
                serviceb.Phone = createServiceProviderDto.Phone;
                serviceb.ProfileImage = createServiceProviderDto.ProfileImage;
                serviceb.UserId = createServiceProviderDto.UserId;
                serviceb.CreationDate = DateTime.Now;

                 await _repos.CreateServiceProvider(serviceb);
                var id = await _repos.CreateServiceProvider(serviceb);
                if (id == 0)
                    throw new Exception("Failed To Create Service Provider");
            }
            throw new Exception("User Dose Not Exisit");

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
