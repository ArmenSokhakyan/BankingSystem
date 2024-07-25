using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Repositories;
using BankingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BankingContext _bankingContext;

        public LoanRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            _bankingContext.Loans.Add(loan);
            await _bankingContext.SaveChangesAsync();
        }

        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _bankingContext.Loans.FindAsync(id);

            if (loan != null) 
            {
                _bankingContext.Loans.Remove(loan);
                await _bankingContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            return await _bankingContext.Loans.ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _bankingContext.Loans.FindAsync(id);
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            _bankingContext.Loans.Update(loan);
            await _bankingContext.SaveChangesAsync();
        }
    }
}
