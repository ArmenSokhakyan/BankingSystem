using BankingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingSystem.Infrastructure.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.CreatedDate)
                .IsRequired();

            builder.Property(i => i.HolderName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.Number)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(x => x.Number)
                .IsUnique();
        }
    }
}
