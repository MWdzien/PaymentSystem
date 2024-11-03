using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs;

public class UpdateCompanyClientDTO
{
    [Required]
    [MaxLength(100)]
    public string CompanyName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}