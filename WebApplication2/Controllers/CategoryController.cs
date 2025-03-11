using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    // private readonly ICategoryService _categoryService = categoryService;
    public int UserId => int.Parse(User.Claims.First(i => i.Type == "id").Value);

    [HttpPost]
    public async Task Create(string name, Type type)
    {
        await categoryService.Create(UserId, name, type);
    }

    [HttpGet]
    public async Task<IEnumerable<Category?>> GetAll()
    {
        return await categoryService.GetAll(UserId);
    }

    [HttpPut]
    public async Task<bool> Update(Category category)
    {
        return await categoryService.Update(category);
    }

    [HttpDelete]
    public async Task<bool> Delete(int categoryId)
    {
        return await categoryService.Delete(categoryId);
    }
}