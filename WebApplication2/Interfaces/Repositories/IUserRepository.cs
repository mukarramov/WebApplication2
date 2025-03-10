using System.Data.SqlTypes;
using WebApplication2.Models;

namespace WebApplication2.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<IEnumerable<User?>> GetAllAsync();
    Task<bool> UpdateAsync(int userId, string email, string password);
    Task<bool> DelateAsync(int userId);

    Task<User?> GetByIdAsync(int userId);
    Task<User?> GetByUserEmailAsync(string email);
    Task<bool> ExistsAsync(string email);
}