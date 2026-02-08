using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WailletAPI.Models;

[Index(nameof(UserName), IsUnique = true)]
public class User
{
    [Key]
    public long UserKey { get; set; }

    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
    
    // Password is now stored as hash + salt (byte[]). We will generate these with PBKDF2.
    [Required]
    public required byte[] PasswordHash { get; set; }

    [Required]
    public required byte[] PasswordSalt { get; set; }

    [Required]
    [MaxLength(100)]
    public required string NickName { get; set; }

    public int Level { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation: one user has many accounts
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}