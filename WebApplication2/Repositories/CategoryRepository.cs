using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Interfaces.Repositories;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(int userId, string name, Type type)
    {
        var newCategory = new Category
        {
            UserId = userId,
            Name = name,
            Type = type
        };

        await _context.Categories.AddAsync(newCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category?>> GetAllCategoryAsync(int userId)
    {
        return await _context.Categories.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var check = false;

        var findById = await _context.Categories.FindAsync(category.Id);
        if (findById == null)
        {
            throw new NullReferenceException("not fount!");
        }

        _context.Entry(findById).CurrentValues.SetValues(category);
        await _context.SaveChangesAsync();

        check = true;

        return check;
    }

    public async Task<bool> DelateAsync(int categoryId)
    {
        var check = false;

        var findId = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
        if (findId == null)
        {
            throw new NullReferenceException("not found!");
        }

        _context.Categories.Remove(findId);
        await _context.SaveChangesAsync();

        check = true;

        return check;
    }

    public Task<Category?> GetByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}