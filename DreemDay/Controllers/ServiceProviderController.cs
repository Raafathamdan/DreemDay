using DreemDay_Core.DTOs.ServiceDTOs;
using DreemDay_Core.DTOs.ServiceProviderDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Prng;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ("Admin,ServiceProvider"))]

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
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetServiceById
        ///    {
        ///       "id":"Enter The Service Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific Service by ID.
        /// </summary>
        /// <returns>GetServiceById</returns>
        /// <response code="201">Returns  GetServiceById</response>
        /// <response code="400">If the error was occured</response>
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
                   var service = await _serviceService.GetService(id);
                    return Ok(service);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateService
        ///     {          
        ///       "ServiceProviderId": "Enter Your new Service ServiceProviderId  Here",   
        ///       "Name": "Enter Your new Service Name Here",   
        ///       "Description": "Enter Your new Service Description Here",   
        ///       "Image": "Enter Your new Service Image Here",   
        ///       "Price": "Enter Your new Service Price Here",   
        ///       "Unit": "Enter Your new Service Unit Here",   
        ///       "MinAmount": "Enter Your new Service MinAmount Here",   
        ///       "MaxAmount": "Enter Your new Service MaxAmount Here",   
        ///       "isHaveDiscount": "Enter Your new Service isHaveDiscount Here",   
        ///       "DiscountAmount": "Enter Your new Service DiscountAmount Here",   
        ///       "PriceAfterDiscount": "Enter Your new Service PriceAfterDiscount Here",   
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New Service.
        /// </summary>
        /// <returns>A newly created Service</returns>
        /// <response code="201">Returns the newly created Service</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateService
        ///    {
        ///       "Id":"Enter The Service Id Here ",
        ///       "ServiceProviderId": "Enter Your new Service ServiceProviderId  Here",   
        ///       "Name": "Enter Your new Service Name Here",   
        ///       "Description": "Enter Your new Service Description Here",   
        ///       "Image": "Enter Your new Service Image Here",   
        ///       "Price": "Enter Your new Service Price Here",   
        ///       "Unit": "Enter Your new Service Unit Here",   
        ///       "MinAmount": "Enter Your new Service MinAmount Here",   
        ///       "MaxAmount": "Enter Your new Service MaxAmount Here",   
        ///       "isHaveDiscount": "Enter Your new Service isHaveDiscount Here",   
        ///       "DiscountAmount": "Enter Your new Service DiscountAmount Here",   
        ///       "PriceAfterDiscount": "Enter Your new Service PriceAfterDiscount Here",
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing Service. 
        /// </summary>
        /// <returns>  Service Has Been Updated  </returns>
        /// <response code="201"> Returns  Service Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/DeleteService
        ///    {
        ///       "Id":"Enter The Service Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a Service
        /// </summary>
        /// <returns>A Service Has Been Deleted</returns>
        /// <response code="201">Returns  Service Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
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
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetServiceProviderById
        ///    {
        ///       "id":"Enter The ServiceProvider Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific ServiceProvider by ID.
        /// </summary>
        /// <returns>GetServiceProviderById</returns>
        /// <response code="201">Returns  ServiceProvider</response>
        /// <response code="400">If the error was occured</response>
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
                   var SP =  await _serviceProviderService.GetServiceProvider(id);
                    return Ok(SP);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateServiceProvider
        ///     {          
        ///       "Name": "Enter Your new ServiceProvider Name Here",   
        ///       "UserId": "Enter Your new ServiceProvider UserId Here",   
        ///       "Email": "Enter Your new ServiceProvider Email Here",   
        ///       "Address": "Enter Your new ServiceProvider Address Here",   
        ///       "ProfileImage": "Enter Your new ServiceProvider ProfileImage Here",   
        ///       "Phone": "Enter Your new ServiceProvider Phone Here",      
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New ServiceProvider.
        /// </summary>
        /// <returns>A newly created ServiceProvider</returns>
        /// <response code="201">Returns the newly created ServiceProvider</response>
        /// <response code="400">If the error was occured</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateServiceProvider([FromBody] CreateServiceProviderDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _serviceProviderService.CreateServiceProvider(dto);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/UpdateServiceProvider
        ///    {
        ///        "Id":"Enter The ServiceProvider Id Here ",
        ///        "Name": "Enter Your new ServiceProvider Name Here",   
        ///       "UserId": "Enter Your new ServiceProvider UserId Here",   
        ///       "Email": "Enter Your new ServiceProvider Email Here",   
        ///       "Address": "Enter Your new ServiceProvider Address Here",   
        ///       "ProfileImage": "Enter Your new ServiceProvider ProfileImage Here",   
        ///       "Phone": "Enter Your new ServiceProvider Phone Here",      
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing ServiceProvider. 
        /// </summary>
        /// <returns>  ServiceProvider Has Been Updated  </returns>
        /// <response code="201"> Returns  ServiceProvider Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
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
