using Microsoft.EntityFrameworkCore;
using WailletAPI.Models;

namespace WailletAPI.Repository;

public class CryptoCurrencyRepository
{
    private readonly Data.WailletDbContext _context;

    public CryptoCurrencyRepository(Data.WailletDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return false;

        var normalized = code.Trim().ToUpperInvariant();
        return await _context.CryptoCurrencies.AnyAsync(c => c.Code == normalized);
    }
}
