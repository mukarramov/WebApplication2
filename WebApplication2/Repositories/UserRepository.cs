using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Interfaces.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(User user)
    {
        var checkEmail = _context.Users.FirstOrDefault(x => x.Email == user.Email);

        if (checkEmail?.Email != null)
        {
            throw new NullReferenceException("this email is exists!");
        }

        string hashPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        user.PasswordHash = hashPassword;
        user.CreateAt = DateTime.Now.ToShortDateString(); 
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<User?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(int userId, string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DelateAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByUserEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public Task<bool> ExistsAsync(string email)
    {
        throw new NotImplementedException();
    }
}