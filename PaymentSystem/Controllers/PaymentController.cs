using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs;
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
        await _paymentService.ProcessPayment(paymentDto.ContractId, paymentDto.Amount);
        return Ok();
    }
}