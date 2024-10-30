using PaymentSystem.DTOs;

namespace PaymentSystem.Services.SubscriptionServices;

public interface ISubscriptionService
{
    public Task CreateSubscription(SubscriptionDTO subscriptionDto);
    public Task RenewSubscription(int subscriptionId);
    public Task<decimal> CalculateSubscriptionRevenue();
}