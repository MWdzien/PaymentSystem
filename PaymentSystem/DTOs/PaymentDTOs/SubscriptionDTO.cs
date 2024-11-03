using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs;

public class SubscriptionDTO
{
    [Required]
    public int ClientId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, 24)]
    public int RenewalPeriodMonths { get; set; }
    [Required]
    public decimal Price { get; set; }
}