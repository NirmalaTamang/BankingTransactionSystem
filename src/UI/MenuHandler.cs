using BankingTransactionSystem.Models;
using BankingTransactionSystem.Services;

namespace BankingTransactionSystem.UI
{
    public class MenuHandler
    {
        private readonly AuthService _authService;
        private readonly TransactionService _transactionService;

        public MenuHandler()
        {
            _authService = new AuthService();
            _transactionService = new TransactionService();
            
        }

        public void Start()
        {
            Console.WriteLine("=== Banking Transaction System ===");

            Console.Write("Enter login: ");
            string login = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter PIN code: ");
            int pinCode = int.Parse(Console.ReadLine() ?? "0");

            Account? account = _authService.Login(login, pinCode);

            if (account == null)
            {
                Console.WriteLine("Invalid login or PIN.");
                return;
            }

            Console.WriteLine("\nLogin successful.");

            if (account.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                ShowAdminMenu(account);
            }
            else if (account.Role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                ShowCustomerMenu(account);
            }
            else
            {
                Console.WriteLine("Unknown account role.");
            }
        }

        private void ShowCustomerMenu(Account account)
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome, {account.HolderName}!");
                Console.WriteLine("1. Withdraw Cash");
                Console.WriteLine("2. Deposit Cash");
                Console.WriteLine("3. Display Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine() ?? string.Empty;

                if (choice == "1")
                {
                    Console.Write("Enter withdrawal amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

                    bool success = _transactionService.Withdraw(account.AccountNumber, amount, out string message);
                    Console.WriteLine(message);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter deposit amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

                    bool success = _transactionService.Deposit(account.AccountNumber, amount, out string message);
                    Console.WriteLine(message);
                }
                else if (choice == "3")
                {
                    decimal? balance = _transactionService.GetBalance(account.AccountNumber);

                    if (balance != null)
                    {
                        Console.WriteLine($"Current balance: {balance}");
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        private void ShowAdminMenu(Account account)
        {
            Console.WriteLine($"\nWelcome, {account.HolderName}!");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Delete Existing Account");
            Console.WriteLine("3. Update Account Information");
            Console.WriteLine("4. Search for Account");
            Console.WriteLine("5. Exit");
        }
    }
}