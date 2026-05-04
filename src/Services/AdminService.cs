using BankingTransactionSystem.Data;
using BankingTransactionSystem.Exceptions;
using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;

    public AdminService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public int CreateAccount(Account account)
    {
        return _accountRepository.CreateAccount(account);
    }

    public bool DeleteAccount(int accountNumber)
    {
        return _accountRepository.DeleteAccount(accountNumber);
    }

    public bool UpdateAccount(Account account)
    {
        return _accountRepository.UpdateAccount(account);
    }

    public Account SearchAccount(int accountNumber)
    {
        return _accountRepository.GetAccountByAccountNumber(accountNumber)
            ?? throw new AccountNotFoundException(accountNumber);
    }
}
