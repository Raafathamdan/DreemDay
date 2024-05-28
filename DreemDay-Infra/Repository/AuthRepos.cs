using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class AuthRepos : IAuthRepos
    {
        public async Task Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task Reset(ResetDto resetDto)
        {
            throw new NotImplementedException();
        }

        public async Task SignUp(SignUpDto signUpDto)
        {
            throw new NotImplementedException();
        }
    }
}
