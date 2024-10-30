namespace PaymentSystem.Services.RevenueServices;

public interface IRevenueService
{
    public Task<decimal> CalculateCurrentRevenue();
    public Task<decimal> CalculateProjectedRevenue();
}