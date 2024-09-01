using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = ("Admin,Customer"))]

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        ///<remarks>
        ///  Sample request:
        ///    Get API/GetPaymentById
        ///    {
        ///       "id":"Enter The Payment Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Retrieve a specific Payment by ID.
        /// </summary>
        /// <returns>GetPaymentById</returns>
        /// <response code="201">Returns  GetPaymentById</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetPaymentById([FromRoute]int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                try
                {
                   var payment = await _paymentService.GetPayments(id);
                    return Ok(payment);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        /// <summary>
        ///  Retrieve a list of Payment.
        /// </summary>
        /// <returns>A List Of All Payment</returns>
        /// <response code="200">Returns  GetAllCustomer</response>
        /// <response code="400">If the error was occured</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
               var payments = await _paymentService.GetAllPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreatePayment
        ///     {          
        ///         
        ///     }
        /// </remarks>
        /// <summary>
        /// Create New Payment.
        /// </summary>
        /// <returns>A newly created Payment</returns>
        /// <response code="201">Returns the newly created Payment</response>
        /// <response code="400">If the error was occured</response>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _paymentService.CreatePayment(dto);
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
        ///    Get API/UpdatePayment
        ///    {
        ///        
        ///    }
        /// </remarks>
        /// <summary>
        /// Update an existing Payment. 
        /// </summary>
        /// <returns>  Payment Has Been Updated  </returns>
        /// <response code="201"> Returns  Payment Has Been Updated</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePayment([FromBody] UpdatePaymentDto dto)
        {
            if (dto.Id == 0)
            {
                return NotFound();
            }
            else if (dto == null )
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _paymentService.UpdatePayment(dto);
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
        ///    Get API/DeletePayment
        ///    {
        ///       "Id":"Enter The Payment Id Here ",
        ///    }
        /// </remarks>
        /// <summary>
        ///  Delete a Payment
        /// </summary>
        /// <returns>A Payment Has Been Deleted</returns>
        /// <response code="201">Returns  Payment Has Been Deleted</response>
        /// <response code="400">If the error was occured</response>
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute]int id)
        {
            if (id  == 0)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _paymentService.DeletePayment(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }
    }
}
