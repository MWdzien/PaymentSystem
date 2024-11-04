using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PaymentSystem.DTOs;
using PaymentSystem.Exceptions;
using PaymentSystem.Services.ClientServices;

namespace PaymentSystem.Controllers;

[Route("api/clients")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("individualClient")]
    public async Task<IActionResult> AddIndividualClient(AddIndividualClientDTO addIndividualClientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _clientService.AddIndividualClient(addIndividualClientDto);
            return Created();
        }
        catch (ResourceAlreadyExistsException)
        {
            return Conflict("Client with given PESEL already exists");
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
    
    [HttpPost("companyClient")]
    public async Task<IActionResult> AddCompanyClient(AddCompanyClientDTO addCompanyClientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _clientService.AddCompanyClient(addCompanyClientDto);
            return Created();
        }
        catch (ResourceAlreadyExistsException e)
        {
            return Conflict(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
    
    [HttpDelete("individualClient/{individualClientId:int}")]
    public async Task<IActionResult> DeleteIndividualClient(int individualClientId)
    {
        try
        {
            await _clientService.DeleteClient(individualClientId);
            return NoContent();
        } catch (Exception e) when (e is ResourceNotFoundException || e is ClientDeletedException)
        {
            return NotFound(e.Message);
        } catch (WrongClientTypeException e)
        {
            return BadRequest(e.Message);
        } catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
    
    [HttpPut("individualClient/{individualClientId:int}")]
    public async Task<IActionResult> UpdateIndividualClient(int individualClientId,
        [FromBody] UpdateIndividualClientDTO updateIndividualClientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _clientService.UpdateIndividualClient(individualClientId, updateIndividualClientDto);
            return NoContent();
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (WrongClientTypeException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }
    
    [HttpPut("companyClient/{companyClientId:int}")]
    public async Task<IActionResult> UpdateCompanyClient(int companyClientId, [FromBody] UpdateCompanyClientDTO updateCompanyClientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _clientService.UpdateCompanyClient(companyClientId, updateCompanyClientDto);
            return NoContent();
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (WrongClientTypeException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
}
    }
}