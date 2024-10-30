using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Repositories.ContractRepositories;

public class ContractRepository : IContractRepository
{
    private readonly DatabaseContext _databaseContext;

    public ContractRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddContract(Contract newContract)
    {
        await _databaseContext.AddAsync(newContract);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteContract(Contract contract)
    {
        _databaseContext.Contracts.Remove(contract);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Contract?> GetContractById(int contractId)
    {
        return await _databaseContext.Contracts.Where(con => con.ContractId == contractId).FirstOrDefaultAsync();
    }

    public async Task<bool> DoesContractExist(Client client, Software software)
    {
        return await _databaseContext.Contracts
            .Where(con => con.ClientId == client.ClientId && con.SoftwareId == software.SoftwareId && !con.IsExpired).AnyAsync();
    }

    public async Task<decimal> CalculateContractRevenue()
    {
        var revenue = 0.0m;
        var contracts = await _databaseContext.Contracts.Where(c => c.IsSigned).ToListAsync();

        foreach (var contract in contracts)
        {
            revenue += contract.Price;
        }

        return revenue;
    }
}