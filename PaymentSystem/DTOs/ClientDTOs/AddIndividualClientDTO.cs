using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs;

public class AddIndividualClientDTO
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must be 11 digits")]
    public string Pesel { get; set; }
}