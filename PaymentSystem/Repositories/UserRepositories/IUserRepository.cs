using PaymentSystem.Models;

namespace PaymentSystem.Repositories.UserRepositories;

public interface IUserRepository
{
    public Task AddUser(User newUser);
    public Task<User?> GetUserByLogin(string login);
}