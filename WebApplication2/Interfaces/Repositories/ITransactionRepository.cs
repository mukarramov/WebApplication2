using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task AddAsync(int userId, int categoryId, Type type, string note);
    Task<IEnumerable<Transaction>?> GetAllTransactionAsync(int userId);
    Task<bool> UpdateAsync(Transaction transaction);
    Task<bool> DeleteAsync(int transactionId);

    Task<Transaction?> GetByIdAsync(int transactionId);
    Task<Transaction?> GetByUserId(int userId);
    Task<Transaction?> GetByCategoryId(int categoryId);
}