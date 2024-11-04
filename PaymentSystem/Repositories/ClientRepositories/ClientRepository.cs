using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.DTOs;
using PaymentSystem.Models;

namespace PaymentSystem.Repositories.ClientRepositories;

public class ClientRepository : IClientRepository

{
    private readonly DatabaseContext _databaseContext;

    public ClientRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddIndividualClient(Client newIndividualClient)
    {
        await _databaseContext.Clients.AddAsync(newIndividualClient);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task AddCompanyClient(Client newCompanyClient)
    {
        await _databaseContext.Clients.AddAsync(newCompanyClient);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteIndividualClient(Client individualClient)
    {
        individualClient.IsDeleted = true;
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateIndividualClient(Client client, UpdateIndividualClientDTO updateIndividualClientDto)
    {
        client.Address = updateIndividualClientDto.Address;
        client.Email = updateIndividualClientDto.Email;
        client.PhoneNumber = updateIndividualClientDto.PhoneNumber;
        client.FirstName = updateIndividualClientDto.FirstName;
        client.LastName = updateIndividualClientDto.LastName;
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateCompanyClient(Client client, UpdateCompanyClientDTO updateCompanyClientDto)
    {
        client.Address = updateCompanyClientDto.Address;
        client.Email = updateCompanyClientDto.Email;
        client.PhoneNumber = updateCompanyClientDto.PhoneNumber;
        client.CompanyName = updateCompanyClientDto.CompanyName;
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Client?> GetClientById(int clientId)
    {
        return await _databaseContext.Clients.Where(c => c.ClientId == clientId).FirstOrDefaultAsync();
    }

    public async Task<bool> DoesClientWithPeselExist(string pesel)
    {
        return await _databaseContext.Clients.AnyAsync(c => c.Pesel != null && c.Pesel == pesel);
    }

    public async Task<bool> DoesClientWithKrsExist(string krs)
    {
        return await _databaseContext.Clients.AnyAsync(c => c.KrsNumber != null && c.KrsNumber == krs);
    }
    
}
