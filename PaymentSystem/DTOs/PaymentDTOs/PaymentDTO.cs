using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs;

public class PaymentDTO
{
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public int ContractId { get; set; }
}