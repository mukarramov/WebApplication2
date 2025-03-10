using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    public async Task Create(int userId, string name, Type type)
    {
        await _categoryService.Create(userId, name, type);
    }

    [HttpGet]
    public async Task<IEnumerable<Category?>> GetAll()
    {
        return await _categoryService.GetAll();
    }

    [HttpPut]
    public async Task<bool> Update(Category category)
    {
        return await _categoryService.Update(category);
    }

    [HttpDelete]
    public async Task<bool> Delete(int categoryId)
    {
        return await _categoryService.Delete(categoryId);
    }
}