using BankingTransactionSystem.UI;

namespace BankingTransactionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.Start();
        }
    }
}