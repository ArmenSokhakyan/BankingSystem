using BankingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Data.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable(nameof(Loan));

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Number)
                .IsRequired();

            builder.Property(i => i.Amount)
                .IsRequired();

            builder.Property(i => i.InterestRate)
                .IsRequired();

            builder.Property(i => i.Term)
                .IsRequired();
            
            builder.Property(i => i.BorrowerName)
                .IsRequired();

        }
    }
}
