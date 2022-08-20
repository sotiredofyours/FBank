using FunctionalBank.WebApi.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunctionalBank.WebApi.Account;

public class AccountEntity
{
    public Guid Id { get; set; }
    public double Balance { get; set; }
    public string Currency { get; set; }
    
    public UserEntity User { get; set; }
}
internal class MeetupEntityTypeConfiguration : IEntityTypeConfiguration<AccountEntity>
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
        entity
            .HasOne(account => account.User);
    }
}