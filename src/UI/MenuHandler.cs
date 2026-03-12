using BankingTransactionSystem.Models;
using BankingTransactionSystem.Services;

namespace BankingTransactionSystem.UI
{
    public class MenuHandler
    {
        private readonly AuthService _authService;
        private readonly TransactionService _transactionService;
        private readonly AdminService _adminService;

        public MenuHandler()
        {
            _authService = new AuthService();
            _transactionService = new TransactionService();
            _adminService = new AdminService();
            
        }

        public void Start()
        {

            while (true)
            {
                Console.WriteLine("=== Banking Transaction System ===");

                Console.Write("Enter login: ");
                string login = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter PIN code: ");
                if (!int.TryParse(Console.ReadLine(), out int pinCode))
                {
                    Console.WriteLine("Invalid PIN format.");
                    ConsoleUtils.PrintDivider();
                    continue;
                }

                Account? account = _authService.Login(login, pinCode);

                if (account == null)
                {
                    Console.WriteLine("Invalid login or PIN.");
                    ConsoleUtils.PrintDivider();
                    continue;
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
                    ConsoleUtils.PrintDivider();
                }

                Console.WriteLine();
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
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.WriteLine("Invalid amount.");
                        ConsoleUtils.PrintDivider();
                        continue;
                    }
                   
                    _transactionService.Withdraw(account.AccountNumber, amount, out string message);
                    if (message.Contains("success", StringComparison.OrdinalIgnoreCase))
                    {
                        decimal? balance = _transactionService.GetBalance(account.AccountNumber);

                        Console.WriteLine("Cash Successfully Withdrawn");
                        Console.WriteLine($"Account #{account.AccountNumber}");
                        Console.WriteLine($"Date: {DateTime.Now:MM/dd/yyyy}");
                        Console.WriteLine($"Withdrawn: {amount:N0}");
                        Console.WriteLine($"Balance: {(balance ?? 0):N0}");
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }

                    ConsoleUtils.PrintDivider();
                }
                else if (choice == "2")
                {
                    Console.Write("Enter deposit amount: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.WriteLine("Invalid amount.");
                        ConsoleUtils.PrintDivider();;
                        continue;
                    }

                    _transactionService.Deposit(account.AccountNumber, amount, out string message);
                    if (message.Contains("success", StringComparison.OrdinalIgnoreCase))
                    {
                        decimal? balance = _transactionService.GetBalance(account.AccountNumber);

                        Console.WriteLine("Cash Deposited Successfully.");
                        Console.WriteLine($"Account #{account.AccountNumber}");
                        Console.WriteLine($"Date: {DateTime.Now:MM/dd/yyyy}");
                        Console.WriteLine($"Deposited: {amount:N0}");
                        Console.WriteLine($"Balance: {(balance ?? 0):N0}");
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }
                    ConsoleUtils.PrintDivider();
                }
                else if (choice == "3")
                {
                    decimal? balance = _transactionService.GetBalance(account.AccountNumber);

                    if (balance != null)
                    {
                        Console.WriteLine($"Account #{account.AccountNumber}");
                        Console.WriteLine($"Date: {DateTime.Now:MM/dd/yyyy}");
                        Console.WriteLine($"Balance: {balance.Value:N0}");
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                                       
                    ConsoleUtils.PrintDivider();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Goodbye.");
                    ConsoleUtils.PrintDivider();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    ConsoleUtils.PrintDivider();
                }
            }
        }

        private void ShowAdminMenu(Account account)
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome, {account.HolderName}!");
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Delete Existing Account");
                Console.WriteLine("3. Update Account Information");
                Console.WriteLine("4. Search for Account");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine() ?? string.Empty;

                if (choice == "1")
                {
                    CreateAccountFlow();
                }
                else if (choice == "2")
                {
                    DeleteAccountFlow();
                }
                else if (choice == "3")
                {
                    UpdateAccountFlow();
                }
                else if (choice == "4")
                {
                    SearchAccountFlow();
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Goodbye.");
                    ConsoleUtils.PrintDivider();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    ConsoleUtils.PrintDivider();
                }
                
            }
        }

        private void CreateAccountFlow()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine() ?? string.Empty;

            Console.Write("PIN Code: ");
            string pinInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(pinInput, out int pinCode) || pinInput.Length != 5)
            {
                Console.WriteLine("Invalid PIN. Pin Code must be a 5-digit integer.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.Write("Holder's Name: ");
            string holderName = Console.ReadLine() ?? string.Empty;

            Console.Write("Starting Balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
            {
                Console.WriteLine("Invalid balance.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.Write("Status (Active/Disabled): ");
            string status = Console.ReadLine() ?? "Active";

            Console.Write("Role (Admin/Customer): ");
            string role = Console.ReadLine() ?? "Customer";

            Account newAccount = new Account
            {
                Login = login,
                PinCode = pinCode,
                HolderName = holderName,
                Balance = balance,
                Status = status,
                Role = role
            };

            int newId = _adminService.CreateAccount(newAccount);
            Console.WriteLine($"Account Successfully Created - the account number assigned is: {newId}");
            ConsoleUtils.PrintDivider();
        }
        
        private void DeleteAccountFlow()
        {
            Console.Write("Enter account number to which you want to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Account? account = _adminService.SearchAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.WriteLine($"You wish to delete the account held by {account.HolderName}. If this information is correct, please re-enter the account number: ");
            if (!int.TryParse(Console.ReadLine(), out int confirmAccountNumber))
            {
                Console.WriteLine("Invalid account number.");
                ConsoleUtils.PrintDivider();
                return;
            }

            if (confirmAccountNumber != accountNumber)
            {
                Console.WriteLine("Account numbers do not match. Delete cancelled.");
                ConsoleUtils.PrintDivider();
                return;
            }

            bool deleted = _adminService.DeleteAccount(accountNumber);

            if (deleted)
            {
                Console.WriteLine("Account Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Account not found or delete failed.");
            }
            ConsoleUtils.PrintDivider();
        }

        private void UpdateAccountFlow()
        {
            Console.Write("Enter account number to update: ");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Account? existingAccount = _adminService.SearchAccount(accountNumber);

            if (existingAccount == null)
            {
                Console.WriteLine("Account not found.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.WriteLine($"Account # {existingAccount.AccountNumber}");
            Console.WriteLine($"Holder: {existingAccount.HolderName}");
            Console.WriteLine($"Balance: {existingAccount.Balance:N0}");
            Console.WriteLine($"Status: {existingAccount.Status}");
            Console.WriteLine($"Login: {existingAccount.Login}");
            Console.WriteLine($"Pin Code: {existingAccount.PinCode}");
            ConsoleUtils.PrintDivider();

            Console.Write($"Login ({existingAccount.Login}): ");
            string login = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(login))
                login = existingAccount.Login;

            Console.Write($"PIN Code ({existingAccount.PinCode}): ");
            string pinInput = Console.ReadLine() ?? string.Empty;
            int pinCode;
            if (string.IsNullOrWhiteSpace(pinInput))
            {
                pinCode = existingAccount.PinCode;
            }
            else if (!int.TryParse(pinInput, out pinCode))
            {
                Console.WriteLine("Invalid PIN.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.Write($"Holder Name ({existingAccount.HolderName}): ");
            string holderName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(holderName))
                holderName = existingAccount.HolderName;

            Console.Write($"Balance ({existingAccount.Balance}): ");
            string balanceInput = Console.ReadLine() ?? string.Empty;
            decimal balance;
            if (string.IsNullOrWhiteSpace(balanceInput))
            {
                balance = existingAccount.Balance;
            }
            else if (!decimal.TryParse(balanceInput, out balance))
            {
                Console.WriteLine("Invalid balance.");
                ConsoleUtils.PrintDivider();
                return;
            }


            Console.Write($"Status ({existingAccount.Status}): ");
            string status = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(status))
                status = existingAccount.Status;

            Console.Write($"Role ({existingAccount.Role}): ");
            string role = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(role))
                role = existingAccount.Role;

            Account updatedAccount = new Account
            {
                AccountNumber = existingAccount.AccountNumber,
                Login = login,
                PinCode = pinCode,
                HolderName = holderName,
                Balance = balance,
                Status = status,
                Role = role
            };

            bool updated = _adminService.UpdateAccount(updatedAccount);

            if (updated)
            {
                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }
            ConsoleUtils.PrintDivider();
        }
        
        private void SearchAccountFlow()
        {
            Console.Write("Enter account number to search: ");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Account? account = _adminService.SearchAccount(accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                ConsoleUtils.PrintDivider();
                return;
            }

            Console.WriteLine("\nThe account information is:");
            Console.WriteLine($"Account #: {account.AccountNumber}");
            Console.WriteLine($"Holder: {account.HolderName}");
            Console.WriteLine($"Balance: {account.Balance:N0}");
            Console.WriteLine($"Status: {account.Status}");
            Console.WriteLine($"Login: {account.Login}");
            Console.WriteLine($"PIN Code: {account.PinCode}");
            Console.WriteLine($"Role: {account.Role}");
            ConsoleUtils.PrintDivider();
        }  
    }
}