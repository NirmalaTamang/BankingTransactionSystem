using BankingTransactionSystem.Models;

Account account = new Account
{
    AccountNumber = 1,
    Login = "testUser",
    PinCode = 12345,
    HolderName = "Test User",
    Balance = 1000
};

Console.WriteLine($"Account created for {account.HolderName}");