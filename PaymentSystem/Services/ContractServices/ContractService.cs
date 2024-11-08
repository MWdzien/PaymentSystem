using PaymentSystem.DTOs.ContractDTOs;
using PaymentSystem.Exceptions;
using PaymentSystem.Models;
using PaymentSystem.Models.ContractModels;
using PaymentSystem.Models.ProductModels;
using PaymentSystem.Repositories.ClientRepositories;
using PaymentSystem.Repositories.ContractRepositories;
using PaymentSystem.Repositories.SoftwareDiscountRepositories;
using PaymentSystem.Repositories.SoftwareRepositories;

namespace PaymentSystem.Services.ContractServices;

public class ContractService : IContractService
{
    private readonly IContractRepository _contractRepository;
    private readonly ISoftwareRepository _softwareRepository;
    private readonly ISoftwareDiscountRepository _softwareDiscountRepository;
    private readonly IClientRepository _clientRepository;


    public ContractService(IContractRepository contractRepository, ISoftwareRepository softwareRepository, ISoftwareDiscountRepository softwareDiscountRepository, IClientRepository clientRepository)
    {
        _contractRepository = contractRepository;
        _softwareRepository = softwareRepository;
        _softwareDiscountRepository = softwareDiscountRepository;
        _clientRepository = clientRepository;
    }


    public async Task AddContract(AddContractDTO addContractDto)
    {
        Client? client = await _clientRepository.GetClientById(addContractDto.ClientId);
        if (client is null) throw new ResourceNotFoundException("Client", addContractDto.ClientId);
        if (client.IsDeleted ?? false) throw new ClientDeletedException(addContractDto.ClientId);
        
        Software? software = await _softwareRepository.GetSoftwareById(addContractDto.SoftwareId);
        if (software is null) throw new ResourceNotFoundException("Software", addContractDto.SoftwareId);

        if (await _contractRepository.DoesContractExist(client, software))
            throw new ResourceAlreadyExistsException($"Active contract for this client and software already exists!");
        
        IsTimespanValid(addContractDto.DateFrom, addContractDto.DateTo);

        

        decimal price = await CalculatePrice(software, client, addContractDto.MaintenanceYears);

        var newContract = new Contract()
        {
            DateFrom = addContractDto.DateFrom,
            DateTo = addContractDto.DateTo,
            Client = client,
            Software = software,
            ClientId = addContractDto.ClientId,
            SoftwareId = addContractDto.SoftwareId,
            IsExpired = DateTime.Today < addContractDto.DateFrom || DateTime.Today > addContractDto.DateTo,
            MaintenanceYears = addContractDto.MaintenanceYears ?? 1,
            Price = price
        };

        await _contractRepository.AddContract(newContract);
    }

    public async Task DeleteContract(int contractId)
    {
        Contract? contract = await _contractRepository.GetContractById(contractId);
        DoesContractExist(contract, contractId);

        await _contractRepository.DeleteContract(contract);
    }

    public void IsTimespanValid(DateTime dateFrom, DateTime dateTo)
    {
        TimeSpan timespan = dateTo - dateFrom;
        if (timespan.Days < 3 || timespan.Days > 30) throw new InvalidTimespanException($"Contracts timespan should be between 3 and 30 days long!");
    }

    public async Task<decimal> CalculatePrice(Software software, Client client, int? maintenanceYears)
    {
        var finalDiscount = 1.0m;
        decimal maintenanceYearsFee = (maintenanceYears ?? 0) * 1000m;
        
        //jezeli klient ponownie korzysta z naszych usług - dodatkowe 5% zniżki
        if (IsReturningClient(client)) finalDiscount -= 0.5m;
        //wybor najwyzszej znizki dla danego software'u
        var maxSoftwareDiscount = await _softwareDiscountRepository.GetHighestDiscountBySoftwareId(software.SoftwareId);
        finalDiscount -= maxSoftwareDiscount / 100;

        return (software.Price + maintenanceYearsFee) * finalDiscount;
    }

    public bool IsReturningClient(Client client)
    {
        return client.Contracts.Any();
    }

    public void DoesContractExist(Contract? contract, int contractId)
    {
        if (contract == null) throw new ResourceNotFoundException("Contract", contractId);
    }

    public async Task<decimal> CalculateContractRevenue()
    {
        return await _contractRepository.CalculateContractRevenue();
    }
}