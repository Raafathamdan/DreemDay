using DreemDay_Core.DTOs.LoginDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface ILoginRepos
    {
        Task<int> CreateLogin(CreateLoginDto loginDto);
    }
}
