using BankingTransactionSystem.Data;
using BankingTransactionSystem.Exceptions;
using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services;

public class TransactionService : ITransactionService
{
    private readonly IAccountRepository _accountRepository;

    public TransactionService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public decimal Withdraw(int accountNumber, decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException(amount);
        }

        var account = _accountRepository.GetAccountByAccountNumber(accountNumber)
            ?? throw new AccountNotFoundException(accountNumber);

        if (amount > account.Balance)
        {
            throw new InsufficientFundsException(amount, account.Balance);
        }

        decimal newBalance = account.Balance - amount;
        _accountRepository.UpdateBalance(accountNumber, newBalance);

        return newBalance;
    }

    public decimal Deposit(int accountNumber, decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException(amount);
        }

        var account = _accountRepository.GetAccountByAccountNumber(accountNumber)
            ?? throw new AccountNotFoundException(accountNumber);

        decimal newBalance = account.Balance + amount;
        _accountRepository.UpdateBalance(accountNumber, newBalance);

        return newBalance;
    }

    public decimal GetBalance(int accountNumber)
    {
        var account = _accountRepository.GetAccountByAccountNumber(accountNumber)
            ?? throw new AccountNotFoundException(accountNumber);

        return account.Balance;
    }
    }
