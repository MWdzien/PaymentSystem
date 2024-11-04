using PaymentSystem.DTOs;
using PaymentSystem.Enums;
using PaymentSystem.Exceptions;
using PaymentSystem.Models;
using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Repositories.PaymentRepositories;
using PaymentSystem.Repositories.SubscriptionRepositories;

namespace PaymentSystem.Services.SubscriptionServices;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IPaymentRepository _paymentRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository, IClientRepository clientRepository, IPaymentRepository paymentRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _clientRepository = clientRepository;
        _paymentRepository = paymentRepository;
    }


    public async Task CreateSubscription(SubscriptionDTO subscriptionDto)
    {
        Client? client = await _clientRepository.GetClientById(subscriptionDto.ClientId);
        if (client == null) throw new ResourceNotFoundException($"Client with ID: {subscriptionDto.ClientId} does not exist");
        if (client.IsDeleted ?? false)
            throw new ClientDeletedException(subscriptionDto.ClientId);

        var discountAmount = client.Contracts.Any(con => con.IsSigned) ? 0.05m : 0.0m;
        var finalPrice = subscriptionDto.Price - (subscriptionDto.Price * discountAmount);

        var subscription = new Subscription()
        {
            ClientId = subscriptionDto.ClientId,
            Name = subscriptionDto.Name,
            RenewalPeriodMonths = subscriptionDto.RenewalPeriodMonths,
            Price = finalPrice,
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now.AddMonths(subscriptionDto.RenewalPeriodMonths),
            Renewals = 1
        };

        await _subscriptionRepository.AddSubscription(subscription);

        var payment = new Payment()
        {
            Amount = finalPrice,
            Date = DateTime.Now,
            PaymentType = PaymentType.Subscription,
            ContractId = subscription.SubscriptionId
        };

        await _paymentRepository.AddPayment(payment);
    }

    public async Task RenewSubscription(int subscriptionId)
    {
        var subscription = await _subscriptionRepository.GetSubscriptionById(subscriptionId);
        if (subscription == null)
            throw new ResourceNotFoundException("Subscription", subscriptionId);
        
        Client? client = await _clientRepository.GetClientById(subscription.ClientId);
        if (client.IsDeleted ?? false) throw new ClientDeletedException(subscription.ClientId);
        
        
        subscription.DateFrom = DateTime.Now;
        subscription.DateTo = DateTime.Now.AddMonths(subscription.RenewalPeriodMonths);
        subscription.Renewals += 1;
        
        var discountAmount = client.Contracts.Any(con => con.IsSigned) ? 0.05m : 0.0m;
        var finalPrice = subscription.Price - (subscription.Price * discountAmount);

        var payment = new Payment()
        {
            Amount = finalPrice,
            Date = DateTime.Now,
            PaymentType = PaymentType.Subscription,
            ContractId = subscriptionId
        };
        
        await _paymentRepository.AddPayment(payment);

        await _subscriptionRepository.UpdateSubscription(subscription);
    }

    public async Task<decimal> CalculateSubscriptionRevenue()
    {
        return await _subscriptionRepository.CalculateSubscriptionRevenue();
    }
}