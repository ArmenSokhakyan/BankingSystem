using BankingSystem.Core.Entities;
using BankingSystem.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        //Models
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model configurations
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfiguration(new LoanConfiguration());

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
