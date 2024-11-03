namespace PaymentSystem.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string Role { get; set; }
}