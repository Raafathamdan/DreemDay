using DreemDay_Core.DTOs.UserDTOs;
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
        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserCardDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserByIdDto> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
