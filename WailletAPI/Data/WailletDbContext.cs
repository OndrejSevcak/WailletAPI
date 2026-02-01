using Microsoft.EntityFrameworkCore;
using WailletAPI.Models;

namespace WailletAPI.Data
{
    public class WailletDbContext : DbContext
    {
        public WailletDbContext(DbContextOptions<WailletDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
