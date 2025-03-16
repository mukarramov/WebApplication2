using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Interfaces.Repositories;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Repositories;

public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(int userId, int categoryId, Type type, string note)
    {
        var newTransaction = new Transaction
        {
            UserId = userId,
            CategoryId = categoryId,
            Type = type,
            Date = DateTime.Now.ToShortDateString(),
            Note = note
        };
        await _context.Transactions.AddAsync(newTransaction);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>?> GetAllTransactionAsync(int userId)
    {
        return await _context.Transactions.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Transaction transaction)
    {
        var check = false;

        var findById = await _context.Transactions.FindAsync(transaction.Id);
        if (findById == null)
        {
            throw new NullReferenceException("not exist!");
        }

        _context.Entry(findById).CurrentValues.SetValues(transaction);
        await _context.SaveChangesAsync();

        check = true;

        return check;
    }

    public async Task<bool> DeleteAsync(int transactionId)
    {
        bool check;

        var findId = context.Transactions.FirstOrDefault(x => x.Id == transactionId);

        if (findId == null)
        {
            throw new NullReferenceException("not found transaction!");
        }

        _context.Transactions.Remove(findId);
        await _context.SaveChangesAsync();

        check = true;

        return check;
    }

    public async Task<Transaction> GetByIdAsync(int transactionId, int userId)
    {
        var findById = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId && x.UserId == userId);

        if (findById == null)
        {
            throw new NullReferenceException("not found!");
        }

        return findById;
    }

    public async Task<List<Transaction>> GetByDate(string date, int userId)
    {
        var findByDate = await _context.Transactions.Where(x => x.Date == date && x.UserId == userId).ToListAsync();

        if (findByDate==null)
        {
            throw new NullReferenceException("the problem in your authorization");
        }

        return findByDate;
    }

    public Task<Transaction?> GetByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction?> GetByCategoryId(int categoryId)
    {
        throw new NotImplementedException();
    }
}