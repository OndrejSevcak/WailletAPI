namespace WailletAPI.Dto;

public class AccountDto
{
    public long AccKey { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Balance { get; set; }
    public bool Active { get; set; }
    public string? CurrencyCode { get; set; }
    public bool CryptoFlag { get; set; }
}