namespace PaymentSystem.DTOs;

public class SubscriptionDTO
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public int RenewalPeriodMonths { get; set; }
    public decimal Price { get; set; }
}