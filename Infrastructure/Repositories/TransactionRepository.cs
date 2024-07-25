using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Repositories;
using BankingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankingContext _bankingContext;

        public TransactionRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            _bankingContext.Transactions.Add(transaction);
            await _bankingContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _bankingContext.Transactions.FindAsync(id);

            if(transaction != null) 
            {
                _bankingContext.Transactions.Remove(transaction);
                await _bankingContext.SaveChangesAsync();
            }
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _bankingContext.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            return await _bankingContext.Transactions.ToListAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _bankingContext.Transactions.Update(transaction);
            await _bankingContext.SaveChangesAsync();
        }
    }
}
