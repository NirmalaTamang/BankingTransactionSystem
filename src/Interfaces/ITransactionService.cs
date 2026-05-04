namespace BankingTransactionSystem.Interfaces;

/// <summary>
/// Defines customer transaction operations.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Withdraws the specified amount from the account.
    /// Throws <see cref="Exceptions.AccountNotFoundException"/> if the account does not exist.
    /// Throws <see cref="Exceptions.InsufficientFundsException"/> if balance is too low.
    /// Throws <see cref="Exceptions.InvalidAmountException"/> if amount is zero or negative.
    /// </summary>
    decimal Withdraw(int accountNumber, decimal amount);

    /// <summary>
    /// Deposits the specified amount into the account.
    /// Throws <see cref="Exceptions.AccountNotFoundException"/> if the account does not exist.
    /// Throws <see cref="Exceptions.InvalidAmountException"/> if amount is zero or negative.
    /// </summary>
    decimal Deposit(int accountNumber, decimal amount);

    /// <summary>
    /// Returns the current balance for the account.
    /// Throws <see cref="Exceptions.AccountNotFoundException"/> if the account does not exist.
    /// </summary>
    decimal GetBalance(int accountNumber);
}
