using BankingTransactionSystem.Exceptions;
using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;
using BankingTransactionSystem.Services;
using Moq;
using Xunit;

namespace BankingTransactionSystem.Tests;

public class AdminServiceTests
{
    private readonly Mock<IAccountRepository> _mockRepo;
    private readonly AdminService _service;

    public AdminServiceTests()
    {
        _mockRepo = new Mock<IAccountRepository>();
        _service = new AdminService(_mockRepo.Object);
    }

    private static Account MakeAccount() => new Account
    {
        AccountNumber = 1,
        Login = "john",
        PinCode = 12345,
        HolderName = "John Doe",
        Balance = 1000,
        Status = "Active",
        Role = "Customer",
    };

    [Fact]
    public void SearchAccount_ValidAccount_ReturnsAccount()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(1)).Returns(MakeAccount());

        Account result = _service.SearchAccount(1);

        Assert.Equal(1, result.AccountNumber);
    }

    [Fact]
    public void SearchAccount_NotFound_ThrowsAccountNotFoundException()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(99)).Returns((Account?)null);

        Assert.Throws<AccountNotFoundException>(() => _service.SearchAccount(99));
    }

    [Fact]
    public void CreateAccount_ValidAccount_ReturnsNewId()
    {
        Account account = MakeAccount();
        _mockRepo.Setup(r => r.CreateAccount(account)).Returns(42);

        int result = _service.CreateAccount(account);

        Assert.Equal(42, result);
    }

    [Fact]
    public void DeleteAccount_ValidAccount_ReturnsTrue()
    {
        _mockRepo.Setup(r => r.DeleteAccount(1)).Returns(true);

        bool result = _service.DeleteAccount(1);

        Assert.True(result);
    }

    [Fact]
    public void DeleteAccount_NotFound_ReturnsFalse()
    {
        _mockRepo.Setup(r => r.DeleteAccount(99)).Returns(false);

        bool result = _service.DeleteAccount(99);

        Assert.False(result);
    }

    [Fact]
    public void UpdateAccount_ValidAccount_ReturnsTrue()
    {
        Account account = MakeAccount();
        _mockRepo.Setup(r => r.UpdateAccount(account)).Returns(true);

        bool result = _service.UpdateAccount(account);

        Assert.True(result);
    }
}

