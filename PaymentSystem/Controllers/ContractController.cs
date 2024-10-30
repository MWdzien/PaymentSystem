using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs.ContractDTOs;
using PaymentSystem.Services.ContractServices;

namespace PaymentSystem.Controllers;

[ApiController]
[Route("api/contract")]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;

    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }
    
    [HttpPost("newContract")]
    public async Task<IActionResult> AddNewContract([FromBody] AddContractDTO addNewContractDto)
    {
        await _contractService.AddContract(addNewContractDto);
        return Created();
    }
    
    [HttpDelete("deleteContract/{contractId:int}")]
    public async Task<IActionResult> DeleteContract(int contractId)
    {
        await _contractService.DeleteContract(contractId);
        return NoContent();
    }
}