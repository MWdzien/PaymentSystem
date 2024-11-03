using PaymentSystem.Repositories.PaymentRepositories;
using PaymentSystem.Repositories.SubscriptionRepositories;
using PaymentSystem.Services.ContractServices;
using PaymentSystem.Services.SubscriptionServices;

namespace PaymentSystem.Services.RevenueServices;

public class RevenueService : IRevenueService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ISubscriptionService _subscriptionService;
    private readonly IContractService _contractService;

    public RevenueService(IPaymentRepository paymentRepository, ISubscriptionService subscriptionService, IContractService contractService)
    {
        _paymentRepository = paymentRepository;
        _subscriptionService = subscriptionService;
        _contractService = contractService;
    }

    public async Task<decimal> CalculateCurrentRevenue()
    {
        var subscriptionRevenue = await _subscriptionService.CalculateSubscriptionRevenue();
        var contractsRevenue = await _contractService.CalculateContractRevenue();

        return subscriptionRevenue + contractsRevenue;
    }

    public async Task<decimal> CalculateProjectedRevenue()
    {
        return await _paymentRepository.CalculateAllPayments();
    }
}