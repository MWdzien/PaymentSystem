using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Repositories.ContractRepositories;

public interface IContractRepository
{
    public Task AddContract(Contract newContract);
    public Task DeleteContract(Contract contract);
    
    public Task<Contract?> GetContractById(int contractId);
    public Task<bool> DoesContractExist(Client client, Software software);
    public Task<decimal> CalculateContractRevenue();
}