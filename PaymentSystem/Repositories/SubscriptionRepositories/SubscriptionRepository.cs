using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Models;

namespace PaymentSystem.Repositories.SubscriptionRepositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly DatabaseContext _databaseContext;

    public SubscriptionRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddSubscription(Subscription subscription)
    {
        await _databaseContext.Subscriptions.AddAsync(subscription);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Subscription?> GetSubscriptionById(int subscriptionId)
    {
        return await _databaseContext.Subscriptions.Where(s => s.SubscriptionId == subscriptionId).FirstOrDefaultAsync();
    }

    public async Task UpdateSubscription(Subscription subscription)
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<decimal> CalculateSubscriptionRevenue()
    {
        var revenue = 0.0m;
        var subscriptions = await _databaseContext.Subscriptions.ToListAsync();

        foreach (var subscription in subscriptions)
        {
            revenue += subscription.Price * subscription.Renewals;
        }

        return revenue;
    }
}