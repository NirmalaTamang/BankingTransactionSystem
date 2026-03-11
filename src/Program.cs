using BankingTransactionSystem.Data;
using MySql.Data.MySqlClient;

namespace BankingTransactionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DatabaseConfig databaseConfig = new DatabaseConfig();

                using MySqlConnection connection = databaseConfig.GetConnection();
                connection.Open();

                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
