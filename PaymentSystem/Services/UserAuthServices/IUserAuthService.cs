using PaymentSystem.DTOs.UserDTOs;
using PaymentSystem.Models;

namespace PaymentSystem.Services.UserAuthServices;

public interface IUserAuthService
{
    public Task<User> RegisterUser(UserDTO userDto);
    public Task<string> LoginUser(UserDTO userDto);
    
    public Task IsLoginUnique(string login);
}