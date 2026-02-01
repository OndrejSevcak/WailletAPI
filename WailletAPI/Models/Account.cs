using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WailletAPI.Models
{
    public class Account
    {
        [Key]
        [Column("acc_key")]
        public long AccKey { get; set; }

        [Column("balance", TypeName = "decimal(19,2)")]
        public decimal Balance { get; set; } = 0;

        [Column("active")] 
        public bool Active { get; set; } = true;

        [Column("created_at", TypeName =  "datetime2")]
        public DateTime CreatedAt { get; set; }

        [Column("currency_code", TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string? CurrencyCode { get; set; } = "EUR";

        [Column("crypto_flag")]
        public bool CryptoFlag { get; set; }
    }
}
