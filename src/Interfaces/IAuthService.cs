using BankingTransactionSystem.Models;

namespace BankingTransactionSystem.Interfaces;

/// <summary>
/// Defines authentication operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Attempts to log in with the given credentials.
    /// Returns the account if successful, null if not found.
    /// </summary>
    Account? Login(string login, int pinCode);
}
