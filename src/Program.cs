using BankingTransactionSystem.Services;
using BankingTransactionSystem.Models;

namespace BankingTransactionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine() ?? "";

            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine() ?? "0");

            AuthService authService = new AuthService();

            Account? account = authService.Login(login, pin);

            if (account != null)
            {
                Console.WriteLine("\nLogin successful!");
                Console.WriteLine($"Account #: {account.AccountNumber}");
                Console.WriteLine($"Holder: {account.HolderName}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Role: {account.Role}");
            }
            else
            {
                Console.WriteLine("\nInvalid login or PIN.");
            }
        }
    }
}