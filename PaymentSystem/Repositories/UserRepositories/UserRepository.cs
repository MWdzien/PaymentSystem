using Microsoft.EntityFrameworkCore;
using PaymentSystem.Context;
using PaymentSystem.Models;

namespace PaymentSystem.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _databaseContext;

    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task AddUser(User newUser)
    {
        await _databaseContext.Users.AddAsync(newUser);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByLogin(string login)
    {
        return await _databaseContext.Users.FirstOrDefaultAsync(u => u.Username == login);
    }
    
}