using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Interfaces;

/// <summary>
/// Defines data access operations for bank accounts.
/// </summary>
public interface IAccountRepository
{
    /// <summary>Finds an account by login and PIN.</summary>
    Account? GetAccountByLoginAndPin(string login, int pinCode);

    /// <summary>Finds an account by its account number.</summary>
    Account? GetAccountByAccountNumber(int accountNumber);

    /// <summary>Updates the balance for the given account.</summary>
    bool UpdateBalance(int accountNumber, decimal newBalance);

    /// <summary>Creates a new account and returns the assigned account number.</summary>
    int CreateAccount(Account account);

    /// <summary>Deletes the account with the given account number.</summary>
    bool DeleteAccount(int accountNumber);

    /// <summary>Updates all fields of an existing account.</summary>
    bool UpdateAccount(Account account);
}
