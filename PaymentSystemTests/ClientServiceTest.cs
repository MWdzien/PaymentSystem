using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Services.ClientServices;

using Moq;
using PaymentSystem.DTOs;
using PaymentSystem.Enums;
using PaymentSystem.Models;
using Xunit;

namespace PaymentSystemTests;

[TestFixture]
public class ClientServiceTest
{
    private ClientService _clientService;
    private Mock<IClientRepository> _clientRepository;

    [SetUp]
    public void SetUp()
    {
        _clientRepository = new Mock<IClientRepository>();
        _clientService = new ClientService(_clientRepository.Object);
    }

    [Fact]
    public async void AddIndividualClient_ClientWithPeselExists_Exception()
    {
        //Arrange
        var pesel = "22222222222";
        
        var client1 = new AddIndividualClientDTO()
        {
            Address = "123 Maple Street",
            Email = "alice.smith@gmail.com",
            FirstName = "Alice",
            LastName = "Smith",
            PhoneNumber = "987654321",
            Pesel = pesel
        };

        var existingClient = new Client()
        {
            Pesel = pesel
        };

        

        
        _clientRepository.Setup(repo => repo.DoesClientWithPeselExist(pesel)).ReturnsAsync(true);
        
        //Act       
        
        //Assert
    }
}