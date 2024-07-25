using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.Models.Entity;
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
        Task<int> CreateService(Service service);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task DeleteService(int id);
    }
}
