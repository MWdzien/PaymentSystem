using System.ComponentModel.DataAnnotations;
using PaymentSystem.Enums;
using PaymentSystem.Models.ContractModels;

namespace PaymentSystem.Models;

public class Client
{
    [Key]
    public int ClientId { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    public ClientType ClientType { get; set; }

    [MaxLength(50)]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must be 11 digits")]
    public string? Pesel { get; set; }

    public bool? IsDeleted { get; set; } = null;
    
    
    [MaxLength(100)] 
    public string? CompanyName { get; set; }
    [RegularExpression(@"^\d{10}$", ErrorMessage = "KRS must be 10 digits")]
    public string? KrsNumber { get; set; }

    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}