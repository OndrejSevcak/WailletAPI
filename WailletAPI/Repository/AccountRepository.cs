using WailletAPI.Models;

namespace WailletAPI.Repository;

public class AccountRepository
{
    private readonly WailletAPI.Data.WailletDbContext _context;

    public AccountRepository(WailletAPI.Data.WailletDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        return _context.Accounts.ToList();
    }

    public Account? GetAccountById(long accKey)
    {
        return _context.Accounts.Find(accKey);
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