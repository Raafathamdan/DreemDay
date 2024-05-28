using DreemDay_Core.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IUserService
    {
        Task<List<UserCardDto>> GetAllUsers();
        Task<UserByIdDto> GetUser(int id);
        Task UpdateUser(UpdateUserDto updateUserDto);
        Task DeleteUser(int id);
    }
}
