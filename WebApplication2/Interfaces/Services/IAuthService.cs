using WebApplication2.Models;

namespace WebApplication2.Interfaces.Services;

public interface IAuthService
{
    Task<string?> AuthenticateAsync(string email, string password);
    Task<bool> RegisterAsync(User user);
}