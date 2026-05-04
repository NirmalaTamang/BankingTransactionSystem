using BankingTransactionSystem.Data;
using BankingTransactionSystem.Exceptions;
using BankingTransactionSystem.Services;
using BankingTransactionSystem.UI;

namespace BankingTransactionSystem;

/// <summary>
/// Application entry point.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point. Builds dependencies and starts the menu.
    /// </summary>
    public static void Main(string[] args)
    {
        try
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            AccountRepository accountRepository = new AccountRepository(databaseConfig);

            AuthService authService = new AuthService(accountRepository);
            TransactionService transactionService = new TransactionService(accountRepository);
            AdminService adminService = new AdminService(accountRepository);

            MenuHandler menuHandler = new MenuHandler(authService, transactionService, adminService);
            menuHandler.Start();
        }
        catch (BankingException ex)
        {
            Console.WriteLine($"Banking error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
