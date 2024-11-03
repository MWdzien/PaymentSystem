using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;

namespace PaymentSystem.Repositories.SoftwareDiscountRepositories;

public class SoftwareDiscountRepository : ISoftwareDiscountRepository
{
    private readonly DatabaseContext _databaseContext;

    public SoftwareDiscountRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }


    public async Task<decimal> GetHighestDiscountBySoftwareId(int softwareId)
    {
        var discountList = await _databaseContext.SoftwareDiscount.Where(sd => sd.SoftwareId == softwareId).ToListAsync();

        return discountList.Max(sd => sd.DiscountRate);
    }
}