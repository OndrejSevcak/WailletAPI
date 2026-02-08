using Microsoft.AspNetCore.Mvc;
using WailletAPI.Dto;
using WailletAPI.Models;
using WailletAPI.Services;

namespace WailletAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _service;

    public AccountController(AccountService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest req)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var accountDto = await _service.CreateAccountAsync(req);
            return CreatedAtAction(nameof(GetAccount), new { id = accountDto.AccKey }, accountDto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
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