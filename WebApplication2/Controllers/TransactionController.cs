using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces.Services;
using WebApplication2.Models;
using Type = WebApplication2.Models.Enums.Type;

namespace WebApplication2.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    private readonly ITransactionService _transactionService = transactionService;
    
    public int UserId => int.Parse(User.Claims.First(i => i.Type == "id").Value);

   // private new int UserId => int.Parse(User.Claims.First(i => i.Type == "id").Value);

    [HttpPost]
    public async Task Create(int categoryId, Type type, string note)
    {
        await _transactionService.Create(UserId, categoryId, type, note);
    }

    [HttpGet]
    public async Task<IEnumerable<Transaction?>> GetAll()
    {
        return await _transactionService.GelAll(UserId);
    }

    [HttpPut]
    public async Task<bool> Update(Transaction transaction)
    {
        return await _transactionService.Update(transaction);
    }

    [HttpDelete]
    public async Task<bool> Delete(int categoryId)
    {
        return await _transactionService.Delete(categoryId);
    }
}