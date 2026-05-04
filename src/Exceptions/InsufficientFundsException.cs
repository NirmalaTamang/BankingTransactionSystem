namespace BankingTransactionSystem.Exceptions;

/// <summary>
/// Thrown when a withdrawal is attempted with insufficient funds.
/// </summary>
public class InsufficientFundsException : BankingException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InsufficientFundsException"/> class.
    /// </summary>
    /// <param name="requested">The amount requested.</param>
    /// <param name="available">The available balance.</param>
    public InsufficientFundsException(decimal requested, decimal available)
        : base($"Insufficient funds. Requested: {requested:C}, Available: {available:C}")
    {
    }
}
