using WebApplication2.Models;

namespace WebApplication2.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}