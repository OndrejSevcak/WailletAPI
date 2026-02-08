using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WailletAPI.Models;

// Converted to entity class stored in DB
public class CryptoCurrency
{
    [Key]
    [Column("code", TypeName = "varchar(10)")]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [Column("name", TypeName = "varchar(100)")]
    [MaxLength(100)]
    public string? Name { get; set; }
}
