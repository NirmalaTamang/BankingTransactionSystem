namespace BankingTransactionSystem.Models
{
    /*This holds AccNum, LoginUsername, 5-digit auth code, AccOwnerName, Balance, Status & Role*/
    public class Account
    {
        public int AccountNumber {get;set;}
        public string Login {get; set;} = string.Empty;
        public int PinCode {get; set;}
        public string HolderName {get; set;} = string.Empty;
        public decimal Balance {get; set;}
        public string Status {get; set;} = "Active";
        public string Role {get; set;} = "Customer";

    }
}