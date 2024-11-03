namespace PaymentSystem.Repositories.SoftwareDiscountRepositories;

public interface ISoftwareDiscountRepository
{
    public Task<decimal> GetHighestDiscountBySoftwareId(int softwareId);

}