using PaymentSystem.Models;

namespace PaymentSystem.Repositories.PaymentRepositories;

public interface IPaymentRepository
{
    public Task AddPayment(Payment payment);
    public Task<decimal> CalculateTotalPayments(int contractId);
    public Task<IEnumerable<Payment>> GetPaymentsByContractId(int contractId);
}