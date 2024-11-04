using PaymentSystem.Enums;
using PaymentSystem.Exceptions;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Repositories.ContractRepositories;
using PaymentSystem.Repositories.PaymentRepositories;

namespace PaymentSystem.Services.PaymentServices;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IContractRepository _contractRepository;

    public PaymentService(IPaymentRepository paymentRepository, IContractRepository contractRepository)
    {
        _paymentRepository = paymentRepository;
        _contractRepository = contractRepository;
    }


    public async Task ProcessPayment(int contractId, decimal amount)
    {
        Contract? contract = await _contractRepository.GetContractById(contractId);
        if (contract == null)
            throw new ResourceNotFoundException("Contract", contractId);
        if (contract.IsExpired)
            throw new InvalidTimespanException($"Contract with ID: {contractId} is not active");

        var totalPayments = await _paymentRepository.CalculateTotalPayments(contractId);
        if (totalPayments + amount >= contract.Price)
        {
            contract.IsSigned = true;
        }

        var payment = new Payment()
        {
            Amount = amount,
            Date = DateTime.Now,
            PaymentType = PaymentType.OneTime,
            ContractId = contractId
        };

        await _paymentRepository.AddPayment(payment);
    }
}