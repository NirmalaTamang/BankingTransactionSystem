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

        public Account? GetAccountByAccountNumber(int accountNumber)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = "SELECT * FROM accounts WHERE account_number = @accountNumber";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@accountNumber", accountNumber);

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

        public bool UpdateBalance(int accountNumber, decimal newBalance)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = "UPDATE accounts SET balance = @balance WHERE account_number = @accountNumber";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@balance", newBalance);
            command.Parameters.AddWithValue("@accountNumber", accountNumber);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        public int CreateAccount(Account account)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = @"INSERT INTO accounts (login, pin_code, holder_name, balance, status, role)
                            VALUES (@login, @pinCode, @holderName, @balance, @status, @role);
                            SELECT LAST_INSERT_ID();";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@login", account.Login);
            command.Parameters.AddWithValue("@pinCode", account.PinCode);
            command.Parameters.AddWithValue("@holderName", account.HolderName);
            command.Parameters.AddWithValue("@balance", account.Balance);
            command.Parameters.AddWithValue("@status", account.Status);
            command.Parameters.AddWithValue("@role", account.Role);

            object result = command.ExecuteScalar()!;
            return Convert.ToInt32(result);
        }

    
        public bool DeleteAccount(int accountNumber)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = "DELETE FROM accounts WHERE account_number = @accountNumber";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@accountNumber", accountNumber);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool UpdateAccount(Account account)
        {
            using MySqlConnection connection = _databaseConfig.GetConnection();
            connection.Open();

            string query = @"UPDATE accounts
                            SET login = @login,
                                pin_code = @pinCode,
                                holder_name = @holderName,
                                balance = @balance,
                                status = @status,
                                role = @role
                            WHERE account_number = @accountNumber";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@login", account.Login);
            command.Parameters.AddWithValue("@pinCode", account.PinCode);
            command.Parameters.AddWithValue("@holderName", account.HolderName);
            command.Parameters.AddWithValue("@balance", account.Balance);
            command.Parameters.AddWithValue("@status", account.Status);
            command.Parameters.AddWithValue("@role", account.Role);
            command.Parameters.AddWithValue("@accountNumber", account.AccountNumber);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

    }
}