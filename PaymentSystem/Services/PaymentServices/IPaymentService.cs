namespace PaymentSystem.Services.PaymentServices;

public interface IPaymentService
{
    public Task ProcessPayment(int contractId, decimal amount);
    
}