using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public Type Type { get; set; }
    public string? Date { get; set; }
    public string? Note { get; set; }
}