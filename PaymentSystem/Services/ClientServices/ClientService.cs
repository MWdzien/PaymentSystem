using PaymentSystem.DTOs;
using PaymentSystem.Enums;
using PaymentSystem.Exceptions;
using PaymentSystem.Models;
using PaymentSystem.Repositories.ClientRepositories;

namespace PaymentSystem.Services.ClientServices;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task AddIndividualClient(AddIndividualClientDTO addIndividualClientDto)
    {
        await IsPeselUnique(addIndividualClientDto.Pesel);

        var newIndividualClient = new Client()
        {
            ClientType = ClientType.IndividualClient,
            Address = addIndividualClientDto.Address,
            Email = addIndividualClientDto.Email,
            PhoneNumber = addIndividualClientDto.PhoneNumber,
            FirstName = addIndividualClientDto.FirstName,
            LastName = addIndividualClientDto.LastName,
            Pesel = addIndividualClientDto.Pesel,
            IsDeleted = false
        };

        await _clientRepository.AddIndividualClient(newIndividualClient);
    }

    public async Task AddCompanyClient(AddCompanyClientDTO addCompanyClientDto)
    {
        await IsKrsUnique(addCompanyClientDto.KrsNumber);

        var newCompanyClient = new Client()
        {
            ClientType = ClientType.CompanyClient,
            Address = addCompanyClientDto.Address,
            Email = addCompanyClientDto.Email,
            PhoneNumber = addCompanyClientDto.PhoneNumber,
            CompanyName = addCompanyClientDto.CompanyName,
            KrsNumber = addCompanyClientDto.KrsNumber
        };

        await _clientRepository.AddCompanyClient(newCompanyClient);
    }

    public async Task DeleteClient(int clientId)
    {
        Client? client = await _clientRepository.GetClientById(clientId);
        DoesClientExist(client, clientId);

        if (client.ClientType == ClientType.CompanyClient)
        {
            throw new WrongClientTypeException($"Can't delete company client");
        }

        await _clientRepository.DeleteIndividualClient(client);
    }

    public async Task UpdateIndividualClient(int individualClientId, UpdateIndividualClientDTO updateIndividualClientDto)
    {
        Client? client = await _clientRepository.GetClientById(individualClientId);
        DoesClientExist(client, individualClientId);
        
        if (client.ClientType == ClientType.CompanyClient)
        {
            throw new WrongClientTypeException($"Client with ID: {individualClientId} is a company client!");
        }

        await _clientRepository.UpdateIndividualClient(client, updateIndividualClientDto);
    }

    public async Task UpdateCompanyClient(int companyClientId, UpdateCompanyClientDTO updateCompanyClientDto)
    {
        Client? client = await _clientRepository.GetClientById(companyClientId);
        DoesClientExist(client, companyClientId);

        if (client.ClientType == ClientType.IndividualClient)
        {
            throw new WrongClientTypeException($"Client with ID: {companyClientId} is a company client!");
        }
        
        await _clientRepository.UpdateCompanyClient(client, updateCompanyClientDto);
    }

    public void DoesClientExist(Client client, int clientId)
    {
        if (client.IsDeleted ?? false) throw new ClientDeletedException(clientId);
        if (client is null) throw new ResourceNotFoundException("Client", clientId);
    }

    public async Task IsPeselUnique(string pesel)
    {
        if (await _clientRepository.DoesClientWithPeselExist(pesel))
            throw new ResourceAlreadyExistsException($"Client with PESEl: {pesel} already exists");
    }

    public async Task IsKrsUnique(string krs)
    {
        if (await _clientRepository.DoesClientWithKrsExist(krs))
            throw new ResourceAlreadyExistsException($"Client with KRS: {krs} already exists");
    }
}