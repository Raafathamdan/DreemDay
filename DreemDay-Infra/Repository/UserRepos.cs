using DreemDay_Core.Context;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
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
        public async Task<int> CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Phone = createUserDto.Phone,
                BirthDate = createUserDto.BirthDate,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return;

            user.IsDeleted = true;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserCardDto>> GetAllUsers()
        {
            return await _dbContext.Users
                           .Where(x => !x.IsDeleted)
                           .Select(user => new UserCardDto
                           {
                               Id = user.Id,
                               FirstName = user.FirstName,
                               LastName = user.LastName
                           })
                           .ToListAsync();
        }

        public async Task<UserByIdDto> GetUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return null;

            return new UserByIdDto
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
        }

        public async Task UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = await _dbContext.Users.FindAsync(updateUserDto.Id);
            if (user == null) return;

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Email = updateUserDto.Email;
            user.Phone = updateUserDto.Phone;
            user.BirthDate = updateUserDto.BirthDate;
            user.IsDeleted = updateUserDto.IsDeleted;
            user.ModifiedDate = DateTime.Now;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
