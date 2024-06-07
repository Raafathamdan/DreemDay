using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.DTOs.UserDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
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

        public async Task Login(LoginDto loginDto)
        {
            await _repos.Login(loginDto);
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
    }
}
