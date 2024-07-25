using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.Helper;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepos _repos;
        private readonly IUserRepos _userRepos;
        private readonly ILoginRepos _loginRepos;

        public AuthService(IAuthRepos repos, IUserRepos userRepos, ILoginRepos loginRepos)
        {
            _repos = repos;
            _userRepos = userRepos;
            _loginRepos = loginRepos;
        }

       

        public async Task<string> Login(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.UserName))
                throw new Exception("User Name Is Required");
            if (string.IsNullOrEmpty(loginDto.Password))
                throw new Exception("Password Is Required");
            var hashPass = HashingHelper.GenerateSHA384String(loginDto.Password);

            var login = await _repos.GetLoginByCredentialsAsync(loginDto.UserName, hashPass);
            if (login == null)
            {
                throw new Exception("Either Username or Password is Incorrect");
            }

            if (!login.IsLoggedIn)
            {
                await _repos.UpdateLoginStatusAsync(login);

                var user = await _repos.GetUserByUserName(loginDto.UserName);
                if (user == null)
                    throw new Exception("User not found");

                var token = TokenHelper.GenerateJwtToken(user);
                return token;
            }
            else
            {
                throw new Exception("You're Already Logged In");
            }
        }


        public async Task Logout(int id)
        {
            await _repos.Logout(id);
        }

        public async Task Reset(ResetDto resetDto)
        {
            await _repos.Reset(resetDto);
        }

        public async Task SignUp(SignUpDto signUpDto)
        {
            await _repos.SignUp(signUpDto);
        }

        

        
        public async Task HashAllPasswordsAsync()
        {
            var logins = await _repos.GetAllLoginsAsync();
            foreach (var login in logins)
            {
                if (!HashingHelper.IsHash(login.Password))
                {
                    login.Password = HashingHelper.GenerateSHA384String(login.Password);
                    _repos.UpdateLogin(login);
                }
            }
            await _repos.SaveChangesAsync();
        }
    }
}
