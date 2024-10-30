using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Enums;
using PaymentSystem.Models;

namespace PaymentSystem.Repositories.PaymentRepositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly DatabaseContext _databaseContext;

    public PaymentRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddPayment(Payment payment)
    {
        await _databaseContext.AddAsync(payment);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<decimal> CalculateTotalPayments(int contractId)
    {
        var totalPayments = 0.0m;
        var payments = await GetPaymentsByContractId(contractId);
        foreach (var payment in payments)
        {
            totalPayments += payment.Amount;
        }

        return totalPayments;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByContractId(int contractId)
    {
        return await _databaseContext.Payments.Where(p => p.ContractId == contractId).ToListAsync();
    }

    
}