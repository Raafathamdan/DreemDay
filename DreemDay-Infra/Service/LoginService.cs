using DreemDay_Core.Context;
using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class LoginService : ILoginSercice
    {
        private readonly ILoginRepos _repos;

        public LoginService(ILoginRepos repos)
        {
            _repos = repos;
        }

        public async Task<int> CreateLogin(CreateLoginDto loginDto)
        {
            return await _repos.CreateLogin(loginDto);
        }
    }
}
