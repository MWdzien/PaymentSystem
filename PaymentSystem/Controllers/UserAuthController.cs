using Microsoft.AspNetCore.Mvc;
using PaymentSystem.DTOs.UserDTOs;
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
        var newUser = await _userAuthService.RegisterUser(registerUserDto);
        return Ok(newUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserDTO loginUserDto)
    {
        var token = await _userAuthService.LoginUser(loginUserDto);
        return Ok(token);
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