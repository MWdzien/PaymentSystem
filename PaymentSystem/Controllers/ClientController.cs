using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PaymentSystem.DTOs;
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
        await _clientService.AddIndividualClient(addIndividualClientDto);
        return Created();
    }
    
    [HttpPost("companyClient")]
    public async Task<IActionResult> AddCompanyClient(AddCompanyClientDTO addCompanyClientDto)
    {
        await _clientService.AddCompanyClient(addCompanyClientDto);
        return Created();
    }
    
    [HttpDelete("individualClient/{individualClientId:int}")]
    public async Task<IActionResult> DeleteIndividualClient(int individualClientId)
    {
        await _clientService.DeleteClient(individualClientId);
        return NoContent();
    }
    
    [HttpPut("individualClient/{individualClientId:int}")]
    public async Task<IActionResult> UpdateIndividualClient(int individualClientId,
        [FromBody] UpdateIndividualClientDTO updateIndividualClientDto)
    {
        await _clientService.UpdateIndividualClient(individualClientId, updateIndividualClientDto);
        return NoContent();
    }
    
    [HttpPut("companyClient/{companyClientId:int}")]
    public async Task<IActionResult> UpdateCompanyClient(int companyClientId, [FromBody] UpdateCompanyClientDTO updateCompanyClientDto)
    {
        await _clientService.UpdateCompanyClient(companyClientId, updateCompanyClientDto);
        return NoContent();
    }
}