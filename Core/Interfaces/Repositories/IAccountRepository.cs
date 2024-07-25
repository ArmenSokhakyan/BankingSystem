using BankingSystem.Core.Entities;

namespace BankingSystem.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(int id);
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int id);

        Account GetAccountByNumber(string accountNumber);
        Account GetAccountById(int id);
    }
}
