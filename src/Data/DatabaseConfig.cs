using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BankingTransactionSystem.Data
{
    public class DatabaseConfig
    {
        private readonly string _connectionString;

        public DatabaseConfig()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
         
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}