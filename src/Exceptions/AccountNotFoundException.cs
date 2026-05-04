namespace BankingTransactionSystem.Exceptions;

/// <summary>
/// Thrown when an account cannot be found by the given identifier.
/// </summary>
public class AccountNotFoundException : BankingException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountNotFoundException"/> class.
    /// </summary>
    /// <param name="accountNumber">The account number that was not found.</param>
    public AccountNotFoundException(int accountNumber)
        : base($"Account {accountNumber} was not found.")
    {
    }
}
