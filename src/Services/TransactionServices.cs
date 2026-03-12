using BankingTransactionSystem.Data;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Services
{
    public class TransactionService
    {
        private readonly AccountRepository _accountRepository;

        public TransactionService()
        {
            _accountRepository = new AccountRepository();
        }

        public bool Withdraw(int accountNumber, decimal amount, out string message)
        {
            if (amount <= 0)
            {
                message = "Withdrawal amount must be greater than zero.";
                return false;
            }

            Account? account = _accountRepository.GetAccountByAccountNumber(accountNumber);

            if (account == null)
            {
                message = "Account not found.";
                return false;
            }

            if (amount > account.Balance)
            {
                message = "Insufficient balance.";
                return false;
            }

            decimal newBalance = account.Balance - amount;
            _accountRepository.UpdateBalance(accountNumber, newBalance);

            message = $"Withdrawal successful. New balance: {newBalance}";
            return true;
        }

        public bool Deposit(int accountNumber, decimal amount, out string message)
        {
            if (amount <= 0)
            {
                message = "Deposit amount must be greater than zero.";
                return false;
            }

            Account? account = _accountRepository.GetAccountByAccountNumber(accountNumber);

            if (account == null)
            {
                message = "Account not found.";
                return false;
            }

            decimal newBalance = account.Balance + amount;
            _accountRepository.UpdateBalance(accountNumber, newBalance);

            message = $"Deposit successful. New balance: {newBalance}";
            return true;
        }

        public decimal? GetBalance(int accountNumber)
        {
            Account? account = _accountRepository.GetAccountByAccountNumber(accountNumber);

            if (account == null)
                return null;

            return account.Balance;
        }
    }
}