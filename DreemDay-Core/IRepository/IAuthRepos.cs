using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface IAuthRepos
    {
        Task SignUp(SignUpDto signUpDto);
        Task UpdateLoginStatusAsync(Login login);
        Task<User> GetUserByUserName(string userName);
        Task Reset(ResetDto resetDto);
        Task Logout(int id);
        Task<Login> GetLoginByCredentialsAsync(string username, string password);
        Task<IEnumerable<Login>> GetAllLoginsAsync();
        void UpdateLogin(Login login);
        Task SaveChangesAsync();


    }
}
