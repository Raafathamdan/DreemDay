using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepos _repos;
        public UserService(IUserRepos repos)
        {
            _repos = repos;
        }
        public async Task CreateUser(CreateUserDto createUserDto)
        {
            var user = new User();

            user.FirstName = createUserDto.FirstName;
            user.LastName = createUserDto.LastName;
            user.Email = createUserDto.Email;
            user.Phone = createUserDto.Phone;
            user.BirthDate = createUserDto.BirthDate;
            user.CreationDate = DateTime.Now;
            user.IsDeleted = false;
            
            await _repos.CreateUser(user);
            var id = await _repos.CreateUser(user);
            if (id == 0)
                throw new Exception("Failed To Create User");

        }

        public async Task DeleteUser(int id)
        {
             await _repos.DeleteUser(id);
        }

        public async Task<List<UserCardDto>> GetAllUsers()
        {
            return await _repos.GetAllUsers();
        }

        public async Task<UserByIdDto> GetUser(int id)
        {
            return await _repos.GetUser(id);
        }

        public async Task UpdateUser(UpdateUserDto updateUserDto)
        {
            await _repos.UpdateUser(updateUserDto);
        }
    }
}
