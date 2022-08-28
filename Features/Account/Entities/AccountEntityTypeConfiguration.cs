using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunctionalBank.WebApi.Features.Account.Entities;

internal class AccountEntityTypeConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> entity)
    {
        entity.ToTable("account");

        entity
            .HasKey(account => account.Id)
            .HasName("pk_account");
    
        entity
            .Property(account => account.Id)
            .HasColumnName("id");

        entity
            .Property(account => account.Balance)
            .HasColumnName("balance");

        entity
            .Property(account => account.Currency)
            .HasColumnName("currency");
       
    }
}