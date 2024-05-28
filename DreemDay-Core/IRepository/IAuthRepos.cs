using DreemDay_Core.DTOs.AuthDTOs;
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
        Task Login(LoginDto loginDto);
        Task Reset(ResetDto resetDto);
    }
}
