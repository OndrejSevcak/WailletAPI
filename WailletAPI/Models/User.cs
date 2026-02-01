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
    
    [Required]
    [MaxLength(256)]
    public required string Password { get; set; }

    [Required]
    [MaxLength(100)]
    public required string NickName { get; set; }

    public int Level { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}