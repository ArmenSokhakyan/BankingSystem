using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Repositories;
using BankingSystem.Core.Interfaces.Services;

namespace BankingSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task AddAccountAsync(Account account)
        {
            await _accountRepository.AddAccountAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _accountRepository.DeleteAccountAsync(id);
        }

        public Account GetAccountById(int id)
        {
            return _accountRepository.GetAccountById(id);
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _accountRepository.GetAccountByNumber(accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAccountAsync(account);
        }
    }
}
