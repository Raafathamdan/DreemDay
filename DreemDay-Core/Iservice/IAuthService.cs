using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface IAuthService
    {
        Task SignUp(SignUpDto signUpDto);
        Task<string> Login (LoginDto loginDto);
        Task Reset (ResetDto resetDto);
        Task HashAllPasswordsAsync();
        Task Logout(int id);

    }
}
