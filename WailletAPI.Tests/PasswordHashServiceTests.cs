using System;
using Xunit;
using WailletAPI.Services;

namespace WailletAPI.Tests;

public class PasswordHashServiceTests
{
    private readonly IPasswordHashService _service = new PasswordHashService();

    [Fact]
    public void CreateHash_Then_Verify_ReturnsTrue()
    {
        string password = "MyS3cret!";
        _service.CreatePasswordHash(password, out var hash, out var salt);

        Assert.NotNull(hash);
        Assert.NotNull(salt);
        Assert.True(_service.VerifyPassword(password, hash, salt));
    }

    [Fact]
    public void Verify_WrongPassword_ReturnsFalse()
    {
        string password = "CorrectHorseBatteryStaple";
        _service.CreatePasswordHash(password, out var hash, out var salt);

        Assert.False(_service.VerifyPassword("wrong-password", hash, salt));
    }

    [Fact]
    public void CreatePasswordHash_Empty_Throws()
    {
        Assert.Throws<ArgumentException>(() => _service.CreatePasswordHash("", out _, out _));
    }
}
