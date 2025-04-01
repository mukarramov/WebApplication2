using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Interfaces.Repositories;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task AddAsync(int userId, string name, Type type)
    {
        var newCategory = new Category
        {
            UserId = userId,
            Name = name,
            Type = type
        };

        await context.Categories.AddAsync(newCategory);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category?>> GetAllCategoryAsync(int userId)
    {
        return await context.Categories.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var check = false;

        var findById = await context.Categories.FindAsync(category.Id);
        if (findById == null)
        {
            throw new NullReferenceException("not fount!");
        }

        context.Entry(findById).CurrentValues.SetValues(category);
        await context.SaveChangesAsync();

        check = true;

        return check;
    }

    public async Task<bool> DelateAsync(int categoryId)
    {
        var check = false;

        var findId = context.Categories.FirstOrDefault(x => x.Id == categoryId);
        if (findId == null)
        {
            throw new NullReferenceException("not found!");
        }

        context.Categories.Remove(findId);
        await context.SaveChangesAsync();

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