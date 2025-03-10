using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Interfaces.Services;

public interface ICategoryService
{
    Task<Category?> Create(int userId, string name, Type type);
    Task<IEnumerable<Category?>> GetAll();
    Task<bool> Update(Category category);
    Task<bool> Delete(int categoryId);

    Task<Category?> GetById(int categoryId);
}