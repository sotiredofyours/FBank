using System.ComponentModel.DataAnnotations.Schema;
using FunctionalBank.WebApi.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunctionalBank.WebApi.User;

public class UserEntity
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }

    public ICollection<AccountEntity> UserAccounts { get; set; }
}

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

public class RefreshTokenEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime ExpirationTime { get; set; }
}

internal class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> entity)
    {
        entity.ToTable("refresh_tokens");

        entity
            .HasKey(refreshToken => refreshToken.Id)
            .HasName("pk_refresh_tokens");

        entity
            .Property(refreshToken => refreshToken.Id)
            .HasColumnName("id");

        entity
            .Property(refreshTokenEntity => refreshTokenEntity.UserId)
            .HasColumnName("user_id");

        entity
            .Property(refreshToken => refreshToken.ExpirationTime)
            .HasColumnName("expiration_time");
    }
}