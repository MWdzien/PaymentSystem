using PaymentSystem.Models;

namespace PaymentSystem.Repositories.SubscriptionRepositories;

public interface ISubscriptionRepository
{
    public Task AddSubscription(Subscription subscription);
    public Task<Subscription?> GetSubscriptionById(int subscriptionId);
    public Task UpdateSubscription(Subscription subscription);
    public Task<decimal> CalculateSubscriptionRevenue();
}