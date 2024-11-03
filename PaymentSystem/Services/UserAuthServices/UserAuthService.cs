using System.Security.Claims;
using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Models;
using PaymentSystem.SecurityHelpers;
using PaymentSystem.Repositories.UserRepositories;

namespace PaymentSystem.Services.UserAuthServices;

public class UserAuthService : IUserAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserAuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }


    public async Task<User> RegisterUser(UserDTO userDto)
    {
        await IsLoginUnique(userDto.Username);
        
        SecurityHelper.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var newUser = new User()
        {
            Username = userDto.Username,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
            Role = "user",
        };

        await _userRepository.AddUser(newUser);
        
        return newUser;
    }

    public async Task<string> LoginUser(UserDTO userDto)
    {
        User? user = await _userRepository.GetUserByLogin(userDto.Username);
        if (user is null) throw new Exception($"User with login {userDto.Username} doesn't exist!");

        if (!SecurityHelper.VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
            throw new Exception($"Wrong password");
        

        var accessToken = SecurityHelper.CreateToken(user, _configuration.GetSection("Security:Token").Value);

        return accessToken;
    }

    public async Task IsLoginUnique(string login)
    {
        if (await _userRepository.GetUserByLogin(login) is not null)
            throw new Exception($"Login: {login} is already taken");
    }
}