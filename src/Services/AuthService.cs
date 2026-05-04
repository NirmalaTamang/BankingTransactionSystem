using BankingTransactionSystem.Data;
using BankingTransactionSystem.Interfaces;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services;

public class AuthService : IAuthService
{
    private readonly IAccountRepository _accountRepository;

    public AuthService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Account? Login(string login, int pinCode)
    {
        return _accountRepository.GetAccountByLoginAndPin(login, pinCode);
    }
}
