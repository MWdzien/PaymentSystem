using PaymentSystem.DTOs;
using PaymentSystem.Models;

namespace PaymentSystem.Repositories.ClientRepositories;

public interface IClientRepository
{
    public Task AddIndividualClient(Client newIndividualClient);
    public Task AddCompanyClient(Client newCompanyClient);
    public Task DeleteIndividualClient(Client individualClient);
    public Task UpdateIndividualClient(Client client, UpdateIndividualClientDTO updateIndividualClientDto);
    public Task UpdateCompanyClient(Client client, UpdateCompanyClientDTO updateCompanyClientDto);
    
    public Task<Client?> GetClientById(int clientId);

    public Task<bool> DoesClientWithPeselExist(string pesel);
    public Task<bool> DoesClientWithKrsExist(string krs);
    
}