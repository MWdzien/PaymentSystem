using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Services.RevenueServices;

namespace PaymentSystem.Controllers;

[ApiController]
[Route("api/revenue")]
public class RevenueController : ControllerBase
{
    private readonly IRevenueService _revenueService;

    public RevenueController(IRevenueService revenueService)
    {
        _revenueService = revenueService;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentRevenue()
    {
        var revenue = await _revenueService.CalculateCurrentRevenue();
        return Ok(revenue);
    }
    
    
    [HttpGet("projected")]
    public async Task<IActionResult> GetProjectedRevenue()
    {
        var revenue = await _revenueService.CalculateProjectedRevenue();
        return Ok(revenue);
    }
}