using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Interfaces.Services;

public interface ITransactionService
{
    Task<Transaction?> Create(int userId, int categoryId, Type type, string note);
    Task<IEnumerable<Transaction?>> GelAll(int userId);
    Task<bool> Update(Transaction transaction);
    Task<bool> Delete(int transactionId);

    Task<Transaction?> GetById(int transactionId, int userId);
    Task<List<Transaction>> GetByDate(string date, int userId);

}