using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs.UserDTOs;

public class UserDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}