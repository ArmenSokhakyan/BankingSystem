using BankingSystem.Core.Entities;

namespace BankingSystem.Core.Interfaces.Services
{
    public interface ILoanService
    {
        Task<Loan> GetLoanByIdAasync(int id);
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task AddLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
    }
}
