using BankingTransactionSystem.Data;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services
{
    public class AdminService
    {
        private readonly AccountRepository _accountRepository;

        public AdminService()
        {
            _accountRepository = new AccountRepository();
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

        public Account? SearchAccount(int accountNumber)
        {
            return _accountRepository.GetAccountByAccountNumber(accountNumber);
        }
    }
}