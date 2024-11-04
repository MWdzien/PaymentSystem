using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Exceptions;
using PaymentSystem.Services.UserAuthServices;

namespace PaymentSystem.Controllers;

[ApiController]
[Route("api/auth")]
public class UserAuthController : ControllerBase
{
    private readonly IUserAuthService _userAuthService;

    public UserAuthController(IUserAuthService userAuthService)
    {
        _userAuthService = userAuthService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserDTO registerUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _userAuthService.RegisterUser(registerUserDto);
            return NoContent();
        }
        catch (ResourceAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "UnexpectedError");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserDTO loginUserDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var token = await _userAuthService.LoginUser(loginUserDto);
            return Ok(token);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidPasswordException e)
        {
            return Unauthorized(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error");
        }
    }

    /*
    To be implemented
    
     
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var res = await _userAuthService.RefreshToken(refreshToken);

        return Ok();
    }*/
}