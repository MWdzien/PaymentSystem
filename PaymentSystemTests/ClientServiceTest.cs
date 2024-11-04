using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Services.ClientServices;

using Moq;
using PaymentSystem.DTOs;
using PaymentSystem.Enums;
using PaymentSystem.Exceptions;
using PaymentSystem.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace PaymentSystemTests;


public class ClientServiceTest
{
    private ClientService _clientService;
    private Mock<IClientRepository> _clientRepositoryMock;

    public ClientServiceTest()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _clientService = new ClientService(_clientRepositoryMock.Object);
    }

    [Fact]
    public async Task AddIndividualClient_ValidClient_AddsClientSuccessfully()
    {
        var pesel = "10101010101";
        var client = new AddIndividualClientDTO
        {
            Address = "123 Maple Street",
            Email = "alice.smith@gmail.com",
            FirstName = "Alice",
            LastName = "Smith",
            PhoneNumber = "987654321",
            Pesel = pesel
        };
        _clientRepositoryMock.Setup(repo => repo.DoesClientWithPeselExist(pesel)).ReturnsAsync(false);


        await _clientService.AddIndividualClient(client);
        
        _clientRepositoryMock.Verify(repo => repo.AddIndividualClient(It.IsAny<Client>()), Times.Once);
    }

    [Fact]
    public async Task AddIndividualClient_ClientWithPeselExists_ResourceAlreadyExistsException()
    {
        var pesel = "22222222222";
        var client = new AddIndividualClientDTO()
        {
            Address = "123 Maple Street",
            Email = "alice.smith@gmail.com",
            FirstName = "Alice",
            LastName = "Smith",
            PhoneNumber = "987654321",
            Pesel = pesel
        };
        _clientRepositoryMock.Setup(repo => repo.DoesClientWithPeselExist(pesel)).ReturnsAsync(true);


        await Assert.ThrowsAsync<ResourceAlreadyExistsException>(async () => await _clientService.AddIndividualClient(client));
    }

    [Fact]
    public async Task AddCompanyClient_ValidClient_AddsClientSuccessfully()
    {
        var krs = "1111111111";
        var client = new AddCompanyClientDTO
        {
            Address = "123 Example Street",
            Email = "example.company@gmail.com",
            PhoneNumber = "123456789",
            CompanyName = "Example company",
            KrsNumber = krs
        };
        _clientRepositoryMock.Setup(repo => repo.DoesClientWithKrsExist(krs)).ReturnsAsync(false);

        await _clientService.AddCompanyClient(client);
        
        _clientRepositoryMock.Verify(repo => repo.AddCompanyClient(It.IsAny<Client>()), Times.Once);
        //await Assert.ThrowsAsync<ResourceAlreadyExistsException>(() => _clientService.AddCompanyClient(client));
    }

    [Fact]
    public async Task DeleteClient_ValidClient_ChangesIsDeletedToTrue()
    {
        var clientId = 1;
        var client = new Client()
        {
            ClientId = clientId,
            ClientType = ClientType.IndividualClient,
            IsDeleted = false
        };
        _clientRepositoryMock.Setup(repo => repo.GetClientById(clientId)).ReturnsAsync(client);

        await _clientService.DeleteClient(clientId);
        
        _clientRepositoryMock.Verify(repo => repo.DeleteIndividualClient(client), Times.Once);
    }

    [Fact]
    public async Task DeleteClient_CompanyClient_WrongClientTypeException()
    {
        var clientId = 1;
        var client = new Client()
        {
            ClientId = clientId,
            ClientType = ClientType.CompanyClient
        };
        _clientRepositoryMock.Setup(repo => repo.GetClientById(clientId)).ReturnsAsync(client);

        await Assert.ThrowsAsync<WrongClientTypeException>(async () => await _clientService.DeleteClient(clientId));
    }

    /* to be implemented: 
    UpdateIndividualClient_ValidData_UpdatesClientSuccessfully(), 
    UpdateIndividualClient_ClientDoesntExist_ThrowsResourceNotFoundException() 
    UpdateCompanyClient_ValidData_UpdatesClientSuccessfully(), 
    UpdateCompanyClient_IndividualClient_ThrowsWrongClientTypeException(), 
    */
}