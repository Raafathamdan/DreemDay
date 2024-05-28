using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class AuthService : IAuthService
    {
        public Task Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task Reset(ResetDto resetDto)
        {
            throw new NotImplementedException();
        }

        public Task SignUp(SignUpDto signUpDto)
        {
            throw new NotImplementedException();
        }
    }
}
