using BankingTransactionSystem.Exceptions;
using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;
using BankingTransactionSystem.Services;
using Moq;
using Xunit;

namespace BankingTransactionSystem.Tests;

public class TransactionServiceTests
{
    private readonly Mock<IAccountRepository> _mockRepo;
    private readonly TransactionService _service;

    public TransactionServiceTests()
    {
        _mockRepo = new Mock<IAccountRepository>();
        _service = new TransactionService(_mockRepo.Object);
    }

    private static Account MakeAccount(decimal balance) => new Account
    {
        AccountNumber = 1,
        Login = "test",
        PinCode = 12345,
        HolderName = "Test User",
        Balance = balance,
        Status = "Active",
        Role = "Customer",
    };

    // Withdraw tests
    [Fact]
    public void Withdraw_ValidAmount_ReturnsNewBalance()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(1)).Returns(MakeAccount(500));
        _mockRepo.Setup(r => r.UpdateBalance(1, 300)).Returns(true);

        decimal result = _service.Withdraw(1, 200);

        Assert.Equal(300, result);
    }

    [Fact]
    public void Withdraw_ZeroAmount_ThrowsInvalidAmountException()
    {
        Assert.Throws<InvalidAmountException>(() => _service.Withdraw(1, 0));
    }

    [Fact]
    public void Withdraw_NegativeAmount_ThrowsInvalidAmountException()
    {
        Assert.Throws<InvalidAmountException>(() => _service.Withdraw(1, -50));
    }

    [Fact]
    public void Withdraw_AccountNotFound_ThrowsAccountNotFoundException()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(99)).Returns((Account?)null);

        Assert.Throws<AccountNotFoundException>(() => _service.Withdraw(99, 100));
    }

    [Fact]
    public void Withdraw_InsufficientFunds_ThrowsInsufficientFundsException()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(1)).Returns(MakeAccount(100));

        Assert.Throws<InsufficientFundsException>(() => _service.Withdraw(1, 200));
    }

    // Deposit tests
    [Fact]
    public void Deposit_ValidAmount_ReturnsNewBalance()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(1)).Returns(MakeAccount(500));
        _mockRepo.Setup(r => r.UpdateBalance(1, 700)).Returns(true);

        decimal result = _service.Deposit(1, 200);

        Assert.Equal(700, result);
    }

    [Fact]
    public void Deposit_ZeroAmount_ThrowsInvalidAmountException()
    {
        Assert.Throws<InvalidAmountException>(() => _service.Deposit(1, 0));
    }

    [Fact]
    public void Deposit_NegativeAmount_ThrowsInvalidAmountException()
    {
        Assert.Throws<InvalidAmountException>(() => _service.Deposit(1, -100));
    }

    [Fact]
    public void Deposit_AccountNotFound_ThrowsAccountNotFoundException()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(99)).Returns((Account?)null);

        Assert.Throws<AccountNotFoundException>(() => _service.Deposit(99, 100));
    }

    // GetBalance tests
    [Fact]
    public void GetBalance_ValidAccount_ReturnsBalance()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(1)).Returns(MakeAccount(500));

        decimal result = _service.GetBalance(1);

        Assert.Equal(500, result);
    }

    [Fact]
    public void GetBalance_AccountNotFound_ThrowsAccountNotFoundException()
    {
        _mockRepo.Setup(r => r.GetAccountByAccountNumber(99)).Returns((Account?)null);

        Assert.Throws<AccountNotFoundException>(() => _service.GetBalance(99));
    }
}
