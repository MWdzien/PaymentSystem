using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs;
using PaymentSystem.Exceptions;
using PaymentSystem.Services.SubscriptionServices;

namespace PaymentSystem.Controllers;

[ApiController]
[Route("api/subscriptions")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionDTO subscriptionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _subscriptionService.CreateSubscription(subscriptionDto);
            return NoContent();
        }
        catch (Exception e) when (e is ResourceNotFoundException || e is ClientDeletedException)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }

    [HttpPut("{subscriptionId:int}/renew")]
    public async Task<IActionResult> RenewSubscription(int subscriptionId)
    {
        try
        {
            await _subscriptionService.RenewSubscription(subscriptionId);
            return Ok();
        }
        catch (Exception e) when (e is ResourceNotFoundException || e is ClientDeletedException)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
        
    }
}