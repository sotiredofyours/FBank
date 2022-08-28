using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunctionalBank.WebApi.Features.User.Entity;

public class ConfigurationUserEntity
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> entity)
        {
            entity.ToTable("users");

            entity
                .HasKey(user => user.Id)
                .HasName("pk_users");

            entity
                .HasIndex(user => user.Username)
                .IsUnique()
                .HasDatabaseName("ix_users_username");

            entity
                .Property(user => user.Id)
                .HasColumnName("id");

            entity
                .Property(user => user.Username)
                .HasColumnName("username");

            entity
                .Property(user => user.Password)
                .HasColumnName("password");

            entity
                .HasMany(acc => acc.UserAccounts);
        }
    }
}