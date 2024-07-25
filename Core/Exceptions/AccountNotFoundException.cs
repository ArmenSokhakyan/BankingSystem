namespace BankingSystem.Core.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public int AccountId { get; }

        public AccountNotFoundException() { }

        public AccountNotFoundException(string message) 
            : base (message)
        {
        }

        public AccountNotFoundException(int accountId)
            : this($"Account with ID {accountId} was not found.")
        {
            AccountId = accountId;
        }
    }
}
