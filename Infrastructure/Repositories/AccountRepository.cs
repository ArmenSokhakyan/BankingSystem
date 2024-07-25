using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Repositories;
using BankingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingContext _bankingContext;

        public AccountRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }
        
        public async Task AddAccountAsync(Account account)
        {
            _bankingContext.Accounts.Add(account);
            await _bankingContext.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _bankingContext.Accounts.FindAsync(id);

            if (account != null) 
            {
                _bankingContext.Accounts.Remove(account);
                await _bankingContext.SaveChangesAsync();
            }
        }

        public Account GetAccountById(int id)
        {
            return _bankingContext.Accounts.Find(id);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _bankingContext.Accounts.FindAsync(id);
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _bankingContext.Accounts.FirstOrDefault(i => i.Number == accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _bankingContext.Accounts.ToListAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _bankingContext.Accounts.Update(account);
            await _bankingContext.SaveChangesAsync();
        }
    }
}
