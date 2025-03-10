using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(int userId, string name, Type type);
    Task<IEnumerable<Category?>> GetAllCategoryAsync(int userId);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DelateAsync(int categoryId);

    Task<Category?> GetByIdAsync(int categoryId);
    Task<Category?> GetByUserId(int userId);
    Task<Category?> GetByNameAsync(string name);
}