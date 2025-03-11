using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        if (user.Email == null || user.PasswordHash == null)
        {
            throw new NullReferenceException("email and password is null!");
        }

        var token = await _authService.AuthenticateAsync(user.Email, user.PasswordHash);
        if (token == null)
        {
            throw new Exception("not found!");
        }

        return Ok(token);
    }

    [HttpPost("register/user")]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        var success = await _authService.RegisterAsync(user);
        if (!success)
        {
            return BadRequest("not found!");
        }

        return Ok(success);
    }
}