using DreemDay_Core.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IServiceRepos
    {
        Task<List<ServiceCardDto>> GetAllService();
        Task<ServiceByIdDto> GetService(int id);
        Task CreateService(CreateServiceDto createServiceDto);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task DeleteService(int id);
    }
}
