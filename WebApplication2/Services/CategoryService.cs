using WebApplication2.Interfaces.Repositories;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Category?> Create(int userId, string name, Type type)
    {
        await _categoryRepository.AddAsync(userId, name, type);

        var newCategory = new Category
        {
            UserId = userId,
            Name = name,
            Type = type
        };

        return newCategory;
    }

    public async Task<IEnumerable<Category?>> GetAll(int userId)
    {
        return await _categoryRepository.GetAllCategoryAsync(userId);
    }

    public async Task<bool> Update(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }

    public async Task<bool> Delete(int categoryId)
    {
        return await _categoryRepository.DelateAsync(categoryId);
    }

    public Task<Category?> GetById(int categoryId)
    {
        throw new NotImplementedException();
    }
}