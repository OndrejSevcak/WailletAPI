using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WailletAPI.Models;
using WailletAPI.Repository;

namespace WailletAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountRepository _repository;

    public AccountController(AccountRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount()
    {
        Account acc = new Account
        {
            CreatedAt = DateTime.UtcNow,
            Balance = 0,
            Active = true,
            CurrencyCode = "EUR",
            CryptoFlag = false
        };
        
        await _repository.AddAccount(acc);

        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetAccount(long id)
    {
        return Ok(new Account
        {
            AccKey = id,
            CreatedAt = DateTime.UtcNow,
            Balance = 1000,
            Active = true,
            CurrencyCode = "EUR",
            CryptoFlag = false
        });
    }
}