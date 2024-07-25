using DreemDay_Core.Context;
using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.Helper;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using DreemDay_Infra.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class AuthRepos : IAuthRepos
    {
        private readonly DreemDayDbContext _dbContext;
        private readonly IUserRepos _userRepos;
        private readonly ILoginRepos _loginRepos;

        public AuthRepos(DreemDayDbContext dbContext, IUserRepos userRepos, ILoginRepos loginRepos)
        {
            _dbContext = dbContext;
            _userRepos = userRepos;
            _loginRepos = loginRepos;
        }

        public async Task<Login> GetLoginByCredentialsAsync(string username, string password)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }

        public async Task UpdateLoginStatusAsync(Login login)
        {
            login.IsLoggedIn = true;
            _dbContext.Logins.Update(login);
            await _dbContext.SaveChangesAsync();
        }



        public async Task Logout(int id)
        {
            var login = await _dbContext.Logins.FindAsync(id);
            if (login != null)
            {
                login.IsLoggedIn = false;
                _dbContext.Logins.Update(login);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Reset(ResetDto resetDto)
        {
            if (string.IsNullOrEmpty(resetDto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(resetDto.UserName))
                throw new Exception("UserName Is Required");
            if (string.IsNullOrEmpty(resetDto.NewPassword))
                throw new Exception("NewPassword Is Required");

            var userLogin = _dbContext.Users
                           .Join(_dbContext.Logins, u => u.Id, l => l.UserId, (user, login) => new { User = user, Login = login })
                           .FirstOrDefault(x => x.User.Email.Equals(resetDto.Email) && x.Login.UserName.Equals(resetDto.UserName));

            if (userLogin != null)
            {
                userLogin.Login.Password = resetDto.NewPassword;
                _dbContext.Logins.Update(userLogin.Login);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task SignUp(SignUpDto signUpDto)
        {
            var user = new User
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                Phone = signUpDto.Phone,
                BirthDate = signUpDto.BirthDate
            };

            int userId = await _userRepos.CreateUser(user);

            var login = new Login
            {
                UserId = userId,
                UserName = signUpDto.UserName,
                Password = HashingHelper.GenerateSHA384String(signUpDto.Password),
                IsLoggedIn = false
            };

            await _loginRepos.CreateLogin(login);
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var login = await _dbContext.Logins.FirstOrDefaultAsync(x => x.UserName == userName);
          var user =   await _dbContext.Users.FirstOrDefaultAsync(x => x.Id==login.UserId);
            return user;
        }

        public async Task<IEnumerable<Login>> GetAllLoginsAsync()
        {
            return await _dbContext.Logins.ToListAsync();
        }

        public void UpdateLogin(Login login)
        {
            _dbContext.Logins.Update(login);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
