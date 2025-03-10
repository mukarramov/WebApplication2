using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Models;

public class Category
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Name { get; set; }
    public Type Type { get; set; }
}