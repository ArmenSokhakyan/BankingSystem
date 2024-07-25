namespace BankingSystem.Presentation.API.DTOs
{
    public class LoanDTO
    {
        public int LoanId { get; set; }
        public string LoanNumber { get; set; }
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime Term { get; set; }
        public string BorrowerName { get; set; }
    }
}
