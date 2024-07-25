using System.Globalization;

namespace BankingSystem.Presentation.API.DTOs
{
    public class TransactionDTO
    {
        public int TransactionID {  get; set; }
        public string TransactionNumber { get; set; }
        public string SourceAccountNumber { get; set; }
        public string DestiantionAccountNumber { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
