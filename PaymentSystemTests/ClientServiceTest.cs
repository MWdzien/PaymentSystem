using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Services.ClientServices;

using Moq;

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
}