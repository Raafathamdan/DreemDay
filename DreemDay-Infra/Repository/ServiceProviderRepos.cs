using DreemDay_Core.Context;
using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class ServiceProviderRepos : IServiceProviderRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public ServiceProviderRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateServiceProvider(ServiceProvider serviceProvider)
        {
            
            _dbContext.ServiceProviders.Add(serviceProvider);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateServiceProvider Has been Finised Successfully");
            return serviceProvider.Id;
        }

        public async Task DeleteServiceProvider(int id)
        {
            var serviceb = await _dbContext.ServiceProviders.FindAsync(id);
            if (serviceb == null)
                return;
            Log.Information("ServiceProviders Is Exists");

            serviceb.IsDeleted = true;
            _dbContext.ServiceProviders.Update(serviceb);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging DeleteServiceProvider Has been Finised Successfully");

        }

        public async Task<List<ServiceProviderCardDto>> GetAllServiceProviders()
        {
            var SR =  await _dbContext.ServiceProviders
                .Where(x =>x.IsDeleted == false)
                .Select(serviceb => new ServiceProviderCardDto
                { Id = serviceb.Id,
                Name = serviceb.Name,
                ProfileImage= $"https://localhost:44324/Images/{serviceb.ProfileImage}",
                }).ToListAsync();
            Log.Debug("Debugging GetAllServiceProviders Has been Finised Successfully");
            return SR;
        }

        public async Task<ServiceProviderByIdDto> GetServiceProvider(int id)
        {
            var serviceb = await _dbContext.ServiceProviders.Join(_dbContext.Users,sb=>sb.UserId,u=>u.Id,(sb,u)=>new {ServiceProvider=sb,User=u}).FirstOrDefaultAsync(sb => sb.ServiceProvider.Id == id);   
            if (serviceb == null) 
                return null;
            Log.Information("ServiceProviders Is Exists");

            var Sr =  new ServiceProviderByIdDto
            {
                Id = serviceb.ServiceProvider.Id,
                Name = serviceb.ServiceProvider.Name,
                ProfileImage = $"https://localhost:44324/Images/{serviceb.ServiceProvider.ProfileImage}",
                Email = serviceb.ServiceProvider.Email,
                Address = serviceb.ServiceProvider.Address,
                Phone = serviceb.ServiceProvider.Phone,
                UserId = serviceb.User.Id,
                CreationDate = serviceb.ServiceProvider.CreationDate.ToString(),
                ModifiedDate = serviceb.ServiceProvider.ModifiedDate.ToString(),
                IsDeleted = serviceb.ServiceProvider.IsDeleted ?? false,

            };
            Log.Debug("Debugging GetServiceProvider Has been Finised Successfully");
            return Sr;
        }

        public async Task UpdateServiceProvider(UpdateServiceProviderDto updateServiceProviderDto)
        {
            var serviceb = await _dbContext.ServiceProviders.FindAsync(updateServiceProviderDto.Id);
            if (serviceb == null)
                return;
            Log.Information("ServiceProviders Is Exists");
            serviceb.Name = updateServiceProviderDto.Name;
            serviceb.Address = updateServiceProviderDto.Address;
            serviceb.Phone = updateServiceProviderDto.Phone;
            serviceb.Email = updateServiceProviderDto.Email;
            serviceb.IsDeleted = updateServiceProviderDto.IsDeleted;
            serviceb.ProfileImage = updateServiceProviderDto.ProfileImage;
            serviceb.ModifiedDate= DateTime.Now;
            serviceb.UserId = updateServiceProviderDto.UserId;
            _dbContext.ServiceProviders.Update(serviceb);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateServiceProvider Has been Finised Successfully");


        }
    }
}
