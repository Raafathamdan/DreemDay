using DreemDay_Core.Context;
using DreemDay_Core.DTOs.UserDTOs;
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
    public class UserRepos : IUserRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public UserRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateUser(User user)
        {
           
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateUser Has been Finised Successfully");
            return user.Id;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return;
            Log.Information("User Is Exists");

            user.IsDeleted = true;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging DeleteUser Has been Finised Successfully");
        }

        public async Task<List<UserCardDto>> GetAllUsers()
        {
            var users = await _dbContext.Users
                .Where(x => !x.IsDeleted)
                .Select(user => new UserCardDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                })
                .ToListAsync();
            Log.Debug("Debugging GetAllUsers Has been Finised Successfully");
            return users;
        }

        public async Task<UserByIdDto> GetUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return null;
            Log.Information("User Is Exists");

            var U = new UserByIdDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                BirthDate = user.BirthDate.ToString(),
                CreationDate = user.CreationDate.ToString(),
                ModifiedDate = user.ModifiedDate?.ToString(),
                IsDeleted = user.IsDeleted
            };
            Log.Debug("Debugging GetUser Has been Finised Successfully");
            return U;
        }

        public async Task UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = await _dbContext.Users.FindAsync(updateUserDto.Id);
            if (user == null) 
                return;
            Log.Information("User Is Exists");
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;
            user.Phone = updateUserDto.Phone;
            user.BirthDate = updateUserDto.BirthDate;
            user.IsDeleted = updateUserDto.IsDeleted;
            user.ModifiedDate = DateTime.Now;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateUser Has been Finised Successfully");
        }
    }
}
