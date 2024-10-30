using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Repositories.SoftwareRepositories;

public class SoftwareRepository : ISoftwareRepository
{
    private readonly DatabaseContext _databaseContext;

    public SoftwareRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Software?> GetSoftwareById(int softwareId)
    {
        return await _databaseContext.Softwares.Where(s => s.SoftwareId == softwareId).FirstOrDefaultAsync();
    }
    
}