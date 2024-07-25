using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Repositories;
using BankingSystem.Core.Interfaces.Services;

namespace BankingSystem.Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _loanRepository.AddLoanAsync(loan);
        }

        public async Task DeleteLoanAsync(int id)
        {
            await _loanRepository.DeleteLoanAsync(id);
        }

        public async Task<Loan> GetLoanByIdAasync(int id)
        {
            return await _loanRepository.GetLoanByIdAsync(id);
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            return await _loanRepository.GetLoansAsync();
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            await _loanRepository.UpdateLoanAsync(loan);
        }
    }
}
