using DreemDay_Core.DTOs.AuthDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            if (signUpDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _authService.SignUp(signUpDto);
                    return Ok("Account Has Been Created");

                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    var token = await _authService.Login(dto);
                    return Ok(new { Token = token });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
           
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Logout(int id)
        {
            try
            {
                await _authService.Logout(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _authService.Reset(dto);
                    return Ok("Password Has Been Changed");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Hashing()
        {
            await _authService.HashAllPasswordsAsync();
            return Ok();
        }


    }
}
