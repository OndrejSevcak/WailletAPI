using System.ComponentModel.DataAnnotations;
using WailletAPI.Models;

namespace WailletAPI.Dto;

public class CreateAccountRequest
{
    [Required]
    public long UserKey { get; set; }
    
    [Required]
    public bool CryptoFlag { get; set; } = false;
    
    [Required]
    public string? CurrencyCode { get; set; } = "EUR";
    
    public decimal InitialBalance { get; set; } = 0m;
}
