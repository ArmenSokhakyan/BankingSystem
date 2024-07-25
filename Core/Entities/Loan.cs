namespace BankingSystem.Core.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public DateTime Term { get; set; }
        public string BorrowerName { get; set; }
    }
}
