using BankingTransactionSystem.Models;
using MySql.Data.MySqlClient;

namespace BankingTransactionSystem.Data
{
    public class AccountRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public AccountRepository()
        {
            _databaseConfig = new DatabaseConfig();
        }

        public Account? GetAccountByLoginAndPin(string login, int pinCode)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = "SELECT * FROM accounts WHERE login = @login AND pin_code = @pinCode";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@pinCode", pinCode);

            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Account
                {
                    AccountNumber = reader.GetInt32("account_number"),
                    Login = reader.GetString("login"),
                    PinCode = reader.GetInt32("pin_code"),
                    HolderName = reader.GetString("holder_name"),
                    Balance = reader.GetDecimal("balance"),
                    Status = reader.GetString("status"),
                    Role = reader.GetString("role")
                };
            }

            return null;
        }
    }
}