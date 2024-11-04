using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs.ContractDTOs;
using PaymentSystem.Exceptions;
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _contractService.AddContract(addNewContractDto);
            return Created();
        }
        catch (Exception e) when (e is ClientDeletedException || e is ResourceNotFoundException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e) when (e is ResourceAlreadyExistsException || e is InvalidTimespanException)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
    
    [HttpDelete("deleteContract/{contractId:int}")]
    public async Task<IActionResult> DeleteContract(int contractId)
    {
        try
        {
            await _contractService.DeleteContract(contractId);
            return NoContent();
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
}