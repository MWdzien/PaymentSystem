using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs;
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
        await _subscriptionService.CreateSubscription(subscriptionDto);
        return Ok();
    }

    [HttpPut("{subscriptionId:int}/renew")]
    public async Task<IActionResult> RenewSubscription(int subscriptionId)
    {
        await _subscriptionService.RenewSubscription(subscriptionId);
        return Ok();
    }
}