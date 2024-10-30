using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Repositories.SoftwareRepositories;

public interface ISoftwareRepository
{
    public Task<Software?> GetSoftwareById(int softwareId);
}