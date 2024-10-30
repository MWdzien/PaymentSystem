using PaymentSystem.DTOs;
using PaymentSystem.Models;

namespace PaymentSystem.Services.ClientServices;

public interface IClientService
{
    public Task AddIndividualClient(AddIndividualClientDTO addIndividualClientDto);
    public Task AddCompanyClient(AddCompanyClientDTO addCompanyClientDto);
    public Task DeleteClient(int clientId);
    public Task UpdateIndividualClient(int individualClientId, UpdateIndividualClientDTO updateIndividualClientDto);
    public Task UpdateCompanyClient(int companyClientId, UpdateCompanyClientDTO updateCompanyClientDto);
    
    public void DoesClientExist(Client client, int clientId);

    public Task IsPeselUnique(string pesel);
    public Task IsKrsUnique(string krs);
}