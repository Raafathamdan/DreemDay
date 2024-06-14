using DreemDay_Core.Context;
using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace DreemDay_Infra.Repository
{
    public class ServiceRepos : IServiceRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public ServiceRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateService(CreateServiceDto createServiceDto)
        {
            var service = new DreemDay_Core.Models.Entity.Service
            {
                ServiceProviderId = createServiceDto.ServiceProviderId,
                Name = createServiceDto.Name,
                Description = createServiceDto.Description,
                Image = createServiceDto.Image,
                Price = createServiceDto.Price,
                Unit= createServiceDto.Unit,
                MinAmount= createServiceDto.MinAmount,
                MaxAmount= createServiceDto.MaxAmount,
                isHaveDiscount= createServiceDto.isHaveDiscount,
                DiscountAmount = createServiceDto.DiscountAmount,
                PriceAfterDiscount = createServiceDto.PriceAfterDiscount,
                CreationDate= DateTime.Now
                
            };
            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateService Has been Finised Successfully");

            return service.Id;
        }

        public async Task DeleteService(int id)
        {
            var service = await _dbContext.Services.FindAsync(id);
            if (service == null)
                return;
            Log.Information("Service Is Exists");

            service.IsDeleted = true;
            _dbContext.Update(service);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging DeleteService Has been Finised Successfully");

        }


        public async Task<List<ServiceCardDto>> GetAllService()
        {
            var S = await _dbContext.Services
                .Where(x => x.IsDeleted)
                .Join(_dbContext.ServiceProviders, s => s.ServiceProviderId,
                sb => sb.Id, (s, sb) => new {Service=s,ServiceProvider=sb})
                .Select(service => new ServiceCardDto
                {
                    Id = service.Service.Id,
                    ServiceProviderId= service.ServiceProvider.Id,
                    Image = service.Service.Image,
                    Price = service.Service.Price,
                    Name = service.Service.Name,

                }).ToListAsync();
            Log.Debug("Debugging GetAllService Has been Finised Successfully");
            return S;
        }

        public async Task<ServiceByIdDto> GetService(int id)
        {
            var service = await _dbContext.Services
                .Join(_dbContext.ServiceProviders,
                s => s.ServiceProviderId,
                sb => sb.Id, (s, sb) => new {Service=s,ServiceProvider=sb})
                .FirstOrDefaultAsync(s=>s.Service.Id == id);
            if (service == null)
                return null;
            Log.Information("Service Is Exists");

            var S =  new ServiceByIdDto
            {
                Id = service.Service.Id,
                ServiceProviderId = service.ServiceProvider.Id,
                Image = service.Service.Image,
                Price = service.Service.Price,
                Name = service.Service.Name,
                Unit = service.Service.Unit,
                Description = service.Service.Description,
                MaxAmount = service.Service.MaxAmount,
                MinAmount = service.Service.MinAmount,
                DiscountAmount = service.Service.DiscountAmount,
                isHaveDiscount = service.Service.isHaveDiscount,
                PriceAfterDiscount = service.Service.PriceAfterDiscount,
                CreationDate = service.Service.CreationDate.ToString(),
                ModifiedDate = service.Service.ModifiedDate.ToString(),
                IsDeleted = service.Service.IsDeleted,

            };
            Log.Debug("Debugging GetService Has been Finised Successfully");
            return S;
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            var service = await _dbContext.Services.FindAsync(updateServiceDto.Id);
            if (service == null)
                return;
            Log.Information("Service Is Exists");

            service.Price = updateServiceDto.Price;
            service.Name = updateServiceDto.Name;
            service.Unit = updateServiceDto.Unit;
            service.Description = updateServiceDto.Description;
            service.Image = updateServiceDto.Image;
            service.MaxAmount = updateServiceDto.MaxAmount;
            service.MinAmount = updateServiceDto.MinAmount;
            service.isHaveDiscount = updateServiceDto.isHaveDiscount;
            service.DiscountAmount = updateServiceDto.DiscountAmount;
            service.PriceAfterDiscount = updateServiceDto.PriceAfterDiscount;
            service.ModifiedDate= DateTime.Now;
            service.IsDeleted = updateServiceDto.IsDeleted;
            _dbContext.Update(service);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateService Has been Finised Successfully");

        }
    }
}
