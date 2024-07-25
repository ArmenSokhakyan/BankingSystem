using BankingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingSystem.Infrastructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(nameof(Transaction));

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.SourceAccountId)
                .IsRequired();

            builder.Property(i => i.DestinationAccountId)
                .IsRequired();

            builder.Property(i => i.Amount)
                .IsRequired();

            builder.Property(i => i.Date)
                .IsRequired();

            builder.HasOne(i => i.SourceAccount)
                    .WithMany()
                    .HasForeignKey(i => i.SourceAccountId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.DestinationAccount)
                    .WithMany()
                    .HasForeignKey(i => i.DestinationAccountId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
