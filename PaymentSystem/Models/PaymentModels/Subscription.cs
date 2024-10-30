using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.Models;

public class Subscription
{
    public int SubscriptionId { get; set; }
    public string Name { get; set; }
    public int RenewalPeriodMonths { get; set; }
    public decimal Price { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int Renewals { get; set; }

    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
}