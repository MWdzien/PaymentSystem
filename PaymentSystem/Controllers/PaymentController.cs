using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs;
using PaymentSystem.Exceptions;
using PaymentSystem.Services.PaymentServices;

namespace PaymentSystem.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("{contractId:int}/pay")]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentDTO paymentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            await _paymentService.ProcessPayment(paymentDto.ContractId, paymentDto.Amount);
            return Ok();
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidTimespanException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
}