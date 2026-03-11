using BankingTransactionSystem.Data;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services
{
    public class AuthService
    {
        private readonly AccountRepository _accountRepository;

        public AuthService()
        {
            _accountRepository = new AccountRepository();
        }

        public Account? Login(string login, int pinCode)
        {
            return _accountRepository.GetAccountByLoginAndPin(login, pinCode);
        }
    }
}