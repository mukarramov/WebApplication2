using WebApplication2.Interfaces.Repositories;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class AuthService(IUserRepository userRepository, IJwtService jwtService) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<string?> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetByUserEmailAsync(email);
        if (user == null)
        {
            throw new NullReferenceException("not found!");
        }

        var hashPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

        if (!hashPassword)
        {
            throw new FileNotFoundException("not found");
        }

        return _jwtService.GenerateToken(user);
    }

    public async Task<bool> RegisterAsync(User user)
    {
        var check = false;
        await _userRepository.AddAsync(user);
        check = true;
        return check;
    }
}