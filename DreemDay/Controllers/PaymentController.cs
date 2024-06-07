using DreemDay_Core.DTOs.PaymentDTOs;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
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
                    await _paymentService.GetPayments(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                await _paymentService.GetAllPayments();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
