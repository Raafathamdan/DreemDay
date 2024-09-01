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

        public async Task<List<ServiceCardDto>> GetAllCarService()
        {
           var S = await _dbContext.Services
                 .Where(x => x.IsDeleted == false)
                 .Join(_dbContext.ServiceProviders, s => s.ServiceProviderId,
                 sb => sb.Id, (s, sb) => new { Service = s, ServiceProvider = sb })
                 .Join(_dbContext.Categories, ssb => ssb.Service.CategoryId,
                 c => c.Id, (ssb, c) => new { ServiceServiceProvider = ssb, Category = c })
                 .Where(c=>c.Category.Id.Equals(2))
                 .Select(service => new ServiceCardDto
                 {
                     Id = service.ServiceServiceProvider.Service.Id,
                     ServiceProviderId = service.ServiceServiceProvider.ServiceProvider.Id,
                     CategoryId = service.Category.Id,
                     CategoryTitle = service.Category.Title,
                     Image = $"https://localhost:44324/Images/{service.ServiceServiceProvider.Service.Image}",
                     Price = service.ServiceServiceProvider.Service.Price,
                     Name = service.ServiceServiceProvider.Service.Name,

                 }).ToListAsync();
            Log.Debug("Debugging GetAllService Has been Finised Successfully");
            return S;
        }

        public async Task<List<ServiceCardDto>> GetAllHallService()
        {
            var S = await _dbContext.Services
                .Where(x => x.IsDeleted == false)
                .Join(_dbContext.ServiceProviders, s => s.ServiceProviderId,
                sb => sb.Id, (s, sb) => new { Service = s, ServiceProvider = sb })
                .Join(_dbContext.Categories, ssb => ssb.Service.CategoryId,
                c => c.Id, (ssb, c) => new { ServiceServiceProvider = ssb, Category = c })
                .Where(c => c.Category.Id.Equals(1))
                .Select(service => new ServiceCardDto
                {
                    Id = service.ServiceServiceProvider.Service.Id,
                    ServiceProviderId = service.ServiceServiceProvider.ServiceProvider.Id,
                    CategoryId = service.Category.Id,
                    CategoryTitle = service.Category.Title,
                    Image = $"https://localhost:44324/Images/{service.ServiceServiceProvider.Service.Image}",
                    Price = service.ServiceServiceProvider.Service.Price,
                    Name = service.ServiceServiceProvider.Service.Name,

                }).ToListAsync();
            Log.Debug("Debugging GetAllService Has been Finised Successfully");
            return S;
        }

        public async Task<List<ServiceCardDto>> GetAllService()
        {
            var S = await _dbContext.Services
                .Where(x => x.IsDeleted == false)
                .Join(_dbContext.ServiceProviders, s => s.ServiceProviderId,
                sb => sb.Id, (s, sb) => new {Service=s,ServiceProvider=sb})
                .Join(_dbContext.Categories,ssb=>ssb.Service.CategoryId,
                c => c.Id, (ssb,c)=>new {ServiceServiceProvider=ssb,Category=c})
                .Select(service => new ServiceCardDto
                {
                    Id = service.ServiceServiceProvider.Service.Id,
                    ServiceProviderId= service.ServiceServiceProvider.ServiceProvider.Id,
                    CategoryId = service.Category.Id,
                    CategoryTitle = service.Category.Title,
                    Image = $"https://localhost:44324/Images/{service.ServiceServiceProvider.Service.Image}",
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
                Image = $"https://localhost:44324/Images/{service.ServiceServiceProvider.Service.Image}",
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
                IsDeleted = service.ServiceServiceProvider.Service.IsDeleted ?? false,
                 
            };
            Log.Debug("Debugging GetService Has been Finised Successfully");
            return S;
        }

        public async Task<List<ServiceCardDto>> SearchService(string? name, string? categorytitle, double? price)
        {
            var service = await _dbContext.Services.Join(_dbContext.Categories, s => s.CategoryId, c => c.Id, (s, c) => new { Service = s, Category = c }).Join(_dbContext.ServiceProviders,sc => sc.Service.ServiceProviderId,sb => sb.Id, (sc, sb) => new {ServiceCategory=sc,ServiceProvider=sb}).ToListAsync();
            if (name != null) service = await _dbContext.Services.Join(_dbContext.Categories, s => s.CategoryId, c => c.Id, (s, c) => new { Service = s, Category = c }).Join(_dbContext.ServiceProviders, sc => sc.Service.ServiceProviderId, sb => sb.Id, (sc, sb) => new { ServiceCategory = sc, ServiceProvider = sb }).Where(x=>x.ServiceCategory.Service.Name.Contains(name)).ToListAsync();
            if (categorytitle != null) service = await _dbContext.Services.Join(_dbContext.Categories, s => s.CategoryId, c => c.Id, (s, c) => new { Service = s, Category = c }).Join(_dbContext.ServiceProviders, sc => sc.Service.ServiceProviderId, sb => sb.Id, (sc, sb) => new { ServiceCategory = sc, ServiceProvider = sb }).Where(x => x.ServiceCategory.Category.Title.Contains(categorytitle)).ToListAsync();
            if (price != null) service = await _dbContext.Services.Join(_dbContext.Categories, s => s.CategoryId, c => c.Id, (s, c) => new { Service = s, Category = c }).Join(_dbContext.ServiceProviders, sc => sc.Service.ServiceProviderId, sb => sb.Id, (sc, sb) => new { ServiceCategory = sc, ServiceProvider = sb }).Where(x=>x.ServiceCategory.Service.Price.Equals(price)).ToListAsync();
            var result = from s in service
                         select new ServiceCardDto
                         {
                             Id = s.ServiceCategory.Service.Id,
                             ServiceProviderId = s.ServiceProvider.Id,
                             CategoryId = s.ServiceCategory.Category.Id,
                             CategoryTitle = s.ServiceCategory.Category.Title,
                             Name = s.ServiceCategory.Service.Name,
                             Price = s.ServiceCategory.Service.Price,
                             Image = $"https://localhost:44324/Images/{s.ServiceCategory.Service.Image}"
                         };
            return result.ToList();
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
