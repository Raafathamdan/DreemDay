using DreemDay_Core.Context;
using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.IRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using DreemDay_Core.Models.Entity;


namespace DreemDay_Infra.Repository
{
    public class ServiceRepos : IServiceRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public ServiceRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateService(DreemDay_Core.Models.Entity.Service service)
        {
           
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
                .Where(x => !x.IsDeleted)
                .Join(_dbContext.ServiceProviders, s => s.ServiceProviderId,
                sb => sb.Id, (s, sb) => new {Service=s,ServiceProvider=sb})
                .Join(_dbContext.Categories,ssb=>ssb.Service.CategoryId,
                c => c.Id, (ssb,c)=>new {ServiceServiceProvider=ssb,Category=c})
                .Select(service => new ServiceCardDto
                {
                    Id = service.ServiceServiceProvider.Service.Id,
                    ServiceProviderId= service.ServiceServiceProvider.ServiceProvider.Id,
                    CategoryId = service.Category.Id,
                    Image = service.ServiceServiceProvider.Service.Image,
                    Price = service.ServiceServiceProvider.Service.Price,
                    Name = service.ServiceServiceProvider.Service.Name,

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
                .Join(_dbContext.Categories, ssb => ssb.Service.CategoryId,
                c => c.Id, (ssb, c) => new { ServiceServiceProvider = ssb, Category = c })
                .FirstOrDefaultAsync(s=>s.ServiceServiceProvider.Service.Id == id);
            if (service == null)
                return null;
            Log.Information("Service Is Exists");

            var S =  new ServiceByIdDto
            {
                Id = service.ServiceServiceProvider.Service.Id,
                ServiceProviderId = service.ServiceServiceProvider.ServiceProvider.Id,
                CategoryId = service.Category.Id,
                Image = service.ServiceServiceProvider.Service.Image,
                Price = service.ServiceServiceProvider.Service.Price,
                Name = service.ServiceServiceProvider.Service.Name,
                Unit = service.ServiceServiceProvider.Service.Unit,
                Description = service.ServiceServiceProvider.Service.Description,
                MaxAmount = service.ServiceServiceProvider.Service.MaxAmount,
                MinAmount = service.ServiceServiceProvider.Service.MinAmount,
                DiscountAmount = service.ServiceServiceProvider.Service.DiscountAmount,
                isHaveDiscount = service.ServiceServiceProvider.Service.isHaveDiscount,
                PriceAfterDiscount = service.ServiceServiceProvider.Service.PriceAfterDiscount,
                CreationDate = service.ServiceServiceProvider.Service.CreationDate.ToString(),
                ModifiedDate = service.ServiceServiceProvider.Service.ModifiedDate.ToString(),
                IsDeleted = service.ServiceServiceProvider.Service.IsDeleted,

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
