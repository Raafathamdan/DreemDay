using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IServiceService
    {
        Task<List<ServiceCardDto>> GetAllService();
        Task<List<ServiceCardDto>> SearchService(string? name, string? categorytitle,double? price);
        Task<List<ServiceCardDto>> GetAllCarService();
        Task<List<ServiceCardDto>> GetAllHallService();
        Task<ServiceByIdDto> GetService(int id);
        Task CreateService(CreateServiceDto createServiceDto);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task DeleteService(int id);

    }
}
