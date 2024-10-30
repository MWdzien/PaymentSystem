using PaymentSystem.DTOs.ContractDTOs;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Services.ContractServices;

public interface IContractService
{
    public Task AddContract(AddContractDTO addContractDto);
    public Task DeleteContract(int contractId);

    public void IsTimespanValid(DateTime dateFrom, DateTime dateTo);
    public Task<decimal> CalculatePrice(Software software, Client client, int? maintenanceYears);
    public bool IsReturningClient(Client client);
    public void DoesContractExist(Contract? contract, int contractId);
    public Task<decimal> CalculateContractRevenue();
}