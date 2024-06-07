using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderController : ControllerBase
    {
        private readonly IServiceProviderService _serviceProviderService;
        private readonly IServiceService _serviceService;

        public ServiceProviderController(IServiceProviderService serviceProviderService, IServiceService serviceService)
        {
            _serviceProviderService = serviceProviderService;
            _serviceService = serviceService;
        }
        #region Service
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetServiceById ([FromRoute]int id)
        {
            if (id == 0)
            {
                return NotFound("Service Does Not Exist");
            }
            else
            {
                try
                {
                    await _serviceService.GetService(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateService ([FromBody]CreateServiceDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _serviceService.CreateService(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateService ([FromBody]UpdateServiceDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound("Service Does Not Exist");
            }
            else if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _serviceService.UpdateService(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound("Service Does Not Exist");
            }
            else
            {
                try
                {
                    await _serviceService.DeleteService(id);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion
        #region ServiceProvider
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetServiceProviderById([FromRoute] int id)
        {  
            if (id == 0) 
            {
                return NotFound("Service Provider Does Not Exist");
            } 
            else
            {
                try
                {
                    await _serviceProviderService.GetServiceProvider(id);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateServiceProvider([FromBody]UpdateServiceProviderDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound("Service Provider Does Not Exist");
            }
            else if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _serviceProviderService.UpdateServiceProvider(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion
    }
}
