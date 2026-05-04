namespace BankingTransactionSystem.Exceptions;

/// <summary>
/// Thrown when a transaction amount is zero or negative.
/// </summary>
public class InvalidAmountException : BankingException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidAmountException"/> class.
    /// </summary>
    /// <param name="amount">The invalid amount that was provided.</param>
    public InvalidAmountException(decimal amount)
        : base($"Transaction amount must be greater than zero. Got: {amount}")
    {
    }
}
