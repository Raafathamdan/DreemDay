using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IUserRepos
    {
        Task<List<UserCardDto>> GetAllUsers();
        Task<UserByIdDto> GetUser(int id);
        Task<int> CreateUser(User user);
        Task UpdateUser(UpdateUserDto  updateUserDto);
        Task DeleteUser(int id);
    }
}
