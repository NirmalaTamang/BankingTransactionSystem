using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Interfaces;

/// <summary>
/// Defines administrative account management operations.
/// </summary>
public interface IAdminService
{
    /// <summary>Creates a new account and returns the assigned account number.</summary>
    int CreateAccount(Account account);

    /// <summary>Deletes an account by account number. Returns true if deleted.</summary>
    bool DeleteAccount(int accountNumber);

    /// <summary>Updates an existing account's information. Returns true if updated.</summary>
    bool UpdateAccount(Account account);

    /// <summary>
    /// Searches for an account by account number.
    /// Throws <see cref="Exceptions.AccountNotFoundException"/> if not found.
    /// </summary>
    Account SearchAccount(int accountNumber);
}
