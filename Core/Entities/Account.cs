using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankingSystem.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string HolderName { get; set; }
        public string Type{ get; set; }
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
