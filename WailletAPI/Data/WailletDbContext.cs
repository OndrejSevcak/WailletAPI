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
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure UserKey is required (NOT NULL)
            modelBuilder.Entity<Account>()
                .Property(a => a.UserKey)
                .IsRequired();

            // Configure one-to-many: User -> Accounts
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserKey)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique fiat account per user (crypto_flag = 0)
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.UserKey)
                .IsUnique()
                .HasFilter("crypto_flag = 0");

            // Unique crypto account per user per currency (crypto_flag = 1)
            // Use CurrencyCode for crypto accounts as requested
            modelBuilder.Entity<Account>()
                .HasIndex(a => new { a.UserKey, a.CurrencyCode })
                .IsUnique()
                .HasFilter("crypto_flag = 1");

            // Configure CryptoCurrency entity
            modelBuilder.Entity<CryptoCurrency>()
                .HasKey(c => c.Code);

            modelBuilder.Entity<CryptoCurrency>()
                .Property(c => c.Code)
                .HasMaxLength(10)
                .HasColumnName("code");

            modelBuilder.Entity<CryptoCurrency>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            // Seed default crypto currencies
            modelBuilder.Entity<CryptoCurrency>().HasData(
                new CryptoCurrency { Code = "BTC", Name = "Bitcoin" },
                new CryptoCurrency { Code = "ETH", Name = "Ethereum" },
                new CryptoCurrency { Code = "LTC", Name = "Litecoin" }
            );
        }
    }
}
