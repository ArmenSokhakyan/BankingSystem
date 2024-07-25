using BankingSystem.Core.Entities;

namespace BankingSystem.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int id);

        Task<Account> GetAccountByIdAsync(int id);
        Account GetAccountByNumber(string accountNumber);
        Account GetAccountById(int id);
    }
}
