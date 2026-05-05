using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;
using BankingTransactionSystem.Services;
using Moq;
using Xunit;

namespace BankingTransactionSystem.Tests;

public class AuthServiceTests
{
    private readonly Mock<IAccountRepository> _mockRepo;
    private readonly AuthService _service;

    public AuthServiceTests()
    {
        _mockRepo = new Mock<IAccountRepository>();
        _service = new AuthService(_mockRepo.Object);
    }

    [Fact]
    public void Login_ValidCredentials_ReturnsAccount()
    {
        Account expected = new Account
        {
            AccountNumber = 1,
            Login = "john",
            PinCode = 12345,
            HolderName = "John Doe",
            Balance = 1000,
            Status = "Active",
            Role = "Customer",
        };

        _mockRepo.Setup(r => r.GetAccountByLoginAndPin("john", 12345)).Returns(expected);

        Account? result = _service.Login("john", 12345);

        Assert.NotNull(result);
        Assert.Equal("john", result.Login);
    }

    [Fact]
    public void Login_InvalidCredentials_ReturnsNull()
    {
        _mockRepo.Setup(r => r.GetAccountByLoginAndPin("wrong", 00000)).Returns((Account?)null);

        Account? result = _service.Login("wrong", 00000);

        Assert.Null(result);
    }
}
