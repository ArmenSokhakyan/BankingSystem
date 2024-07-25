namespace BankingSystem.Presentation.API.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }
    }
}
