namespace BankingSystem.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionNumber { get; set; }
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Account SourceAccount { get; set; }
        public Account DestinationAccount { get; set; }
    }
}
