using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class ServiceRepos : IServiceRepos
    {
        public Task CreateService(CreateServiceDto createServiceDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceCardDto>> GetAllService()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceByIdDto> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
