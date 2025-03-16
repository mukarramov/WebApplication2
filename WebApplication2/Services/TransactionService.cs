using WebApplication2.Interfaces.Repositories;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public async Task<Transaction?> Create(int userId, int categoryId, Type type, string note)
    {
        var newTransaction = new Transaction
        {
            UserId = userId,
            CategoryId = categoryId,
            Type = type,
            Date = DateTime.Now.ToShortDateString(),
            Note = note
        };

        await _transactionRepository.AddAsync(userId, categoryId, type, note);

        return newTransaction;
    }

    public async Task<IEnumerable<Transaction?>> GelAll(int userId)
    {
        return await _transactionRepository.GetAllTransactionAsync(userId) ?? throw new InvalidOperationException();
    }

    public async Task<bool> Update(Transaction transaction)
    {
        var check = false;

        await _transactionRepository.UpdateAsync(transaction);

        check = true;
        return check;
    }

    public async Task<bool> Delete(int transactionId)
    {
        return await _transactionRepository.DeleteAsync(transactionId);
    }

    public async Task<Transaction?> GetById(int transactionId, int userId)
    {
        return await _transactionRepository.GetByIdAsync(transactionId, userId);
    }

    public async Task<List<Transaction>> GetByDate(string date, int userId)
    {
        return await _transactionRepository.GetByDate(date, userId);
    }
}