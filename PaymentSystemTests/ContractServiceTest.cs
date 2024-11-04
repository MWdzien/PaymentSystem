using Moq;
using PaymentSystem.DTOs.ContractDTOs;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;
using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Repositories.ContractRepositories;
using PaymentSystem.Repositories.SoftwareDiscountRepositories;
using PaymentSystem.Repositories.SoftwareRepositories;
using PaymentSystem.Services.ContractServices;
using Xunit;

namespace PaymentSystemTests;

public class ContractServiceTest
{
    private readonly Mock<IContractRepository> _contractRepositoryMock;
    private readonly Mock<ISoftwareRepository> _softwareRepositoryMock;
    private readonly Mock<ISoftwareDiscountRepository> _softwareDiscountRepositoryMock;
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private readonly ContractService _contractService;

    public ContractServiceTest()
    {
        _contractRepositoryMock = new Mock<IContractRepository>();
        _softwareRepositoryMock = new Mock<ISoftwareRepository>();
        _softwareDiscountRepositoryMock = new Mock<ISoftwareDiscountRepository>();
        _clientRepositoryMock = new Mock<IClientRepository>();
        _contractService = new ContractService(_contractRepositoryMock.Object, _softwareRepositoryMock.Object,
            _softwareDiscountRepositoryMock.Object, _clientRepositoryMock.Object);
    }
    
    [Fact]
    public async Task AddContract_ValidContract_CreatesContract()
    {
        var contract = new AddContractDTO
        {
            ClientId = 1, 
            SoftwareId = 1, 
            DateFrom = DateTime.Now.AddDays(-5),
            DateTo = DateTime.Now.AddDays(10), 
            MaintenanceYears = 1
        };
        _clientRepositoryMock.Setup(repo => repo.GetClientById(contract.ClientId)).ReturnsAsync(new Client());
        _softwareRepositoryMock.Setup(repo => repo.GetSoftwareById(contract.SoftwareId)).ReturnsAsync(new Software());
        _contractRepositoryMock.Setup(repo => repo.DoesContractExist(It.IsAny<Client>(), It.IsAny<Software>())).ReturnsAsync(false);
        _contractRepositoryMock.Setup(repo => repo.AddContract(It.IsAny<Contract>())).Returns(Task.CompletedTask);

        await _contractService.AddContract(contract);

        _contractRepositoryMock.Verify(repo => repo.AddContract(It.IsAny<Contract>()), Times.Once);
    }
}