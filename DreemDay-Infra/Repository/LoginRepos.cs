using DreemDay_Core.Context;
using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class LoginRepos : ILoginRepos
    {
        private readonly DreemDayDbContext _dbContext;

        public LoginRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateLogin(Login login)
        {
            var log = new Login
            {
                UserId = login.UserId,
                UserName = login.UserName,
                Password = login.Password,
                IsLoggedIn = login.IsLoggedIn,
                CreationDate = DateTime.Now,

            };
            _dbContext.Add(log);  
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging CreateLogin Has been Finised Successfully");
            return login.Id;

        }
    }
}
