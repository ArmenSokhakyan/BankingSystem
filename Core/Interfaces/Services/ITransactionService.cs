using BankingSystem.Core.Entities;

namespace BankingSystem.Core.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
    }
}
