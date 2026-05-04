namespace BankingTransactionSystem.Models;

/// <summary>
/// Represents a bank account in the system.
/// </summary>

    /*This holds AccNum, LoginUsername, 5-digit auth code, AccOwnerName, Balance, Status & Role*/
    public class Account
    {
        /// <summary>Gets the unique account number.</summary>
        public int AccountNumber { get; init; }

        /// <summary>Gets the login username.</summary>
        public string Login { get; init; } = string.Empty;

        /// <summary>Gets the PIN code for authentication.</summary>
        public int PinCode { get; init; }

        /// <summary>Gets the full name of the account holder.</summary>
        public string HolderName { get; init; } = string.Empty;

        /// <summary>Gets the current account balance.</summary>
        public decimal Balance { get; init; }

        /// <summary>Gets the account status (Active or Disabled).</summary>
        public string Status { get; init; } = "Active";

        /// <summary>Gets the account role (Admin or Customer).</summary>
        public string Role { get; init; } = "Customer";
    }
