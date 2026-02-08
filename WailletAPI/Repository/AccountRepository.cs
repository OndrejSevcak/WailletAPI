using Microsoft.EntityFrameworkCore;
using WailletAPI.Models;

namespace WailletAPI.Repository;

public class AccountRepository
{
    private readonly Data.WailletDbContext _context;

    public AccountRepository(Data.WailletDbContext context)
    {
        _context = context;
    }

    public async Task AddAccount(Account account)
    {
        if (account.UserKey is long userKey)
        {
            if (!account.CryptoFlag)
            {
                var hasFiat = await HasFiatAccountAsync(userKey);
                if (hasFiat)
                    throw new InvalidOperationException("User already has a fiat account");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(account.CurrencyCode))
                {
                    var exists = await _context.Accounts
                        .AnyAsync(a => 
                            a.UserKey == userKey && 
                            a.CryptoFlag && 
                            a.CurrencyCode == account.CurrencyCode);
                    if (exists)
                        throw new InvalidOperationException("User already has a crypto account for this currency");
                }
            }
        }

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Account>> GetAccountsByUserAsync(long userKey)
    {
        return await _context.Accounts.Where(a => a.UserKey == userKey).ToListAsync();
    }

    public async Task<bool> HasFiatAccountAsync(long userKey)
    {
        return await _context.Accounts.AnyAsync(a => a.UserKey == userKey && !a.CryptoFlag);
    }

    public void UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }

    public void DeleteAccount(long accKey)
    {
        var account = _context.Accounts.Find(accKey);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}