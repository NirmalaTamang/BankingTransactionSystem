namespace BankingTransactionSystem.Exceptions;

/// <summary>
/// Base exception for all banking domain errors.
/// </summary>
public class BankingException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BankingException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public BankingException(string message)
        : base(message)
    {
    }
}
