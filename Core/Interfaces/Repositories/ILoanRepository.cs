using BankingSystem.Core.Entities;

namespace BankingSystem.Core.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanByIdAsync(int id);
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task AddLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
    }
}
