using Microsoft.EntityFrameworkCore;
using WailletAPI.Data;
using WailletAPI.Models;

namespace WailletAPI.Repository;

public class UserRepository
{
    private readonly WailletDbContext _context;

    public UserRepository(WailletDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public Task<User?> GetByUserNameAsync(string userName)
    {
        return _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
    }

    public Task<User?> GetByIdAsync(long userKey)
    {
        return _context.Users.FindAsync(userKey).AsTask();
    }
}
