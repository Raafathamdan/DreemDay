using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
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
        public async Task<int> CreateUser(CreateUserDto createUserDto)
        {
            return await _repos.CreateUser(createUserDto);
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
            return await GetUser(id);
        }

        public async Task UpdateUser(UpdateUserDto updateUserDto)
        {
            await _repos.UpdateUser(updateUserDto);
        }
    }
}
