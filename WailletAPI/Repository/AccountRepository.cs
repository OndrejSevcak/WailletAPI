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
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
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