using System.Reflection;
using FunctionalBank.WebApi.Features.Account.Entities;
using FunctionalBank.WebApi.Features.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi;

public class DatabaseContext : DbContext
{
    public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();

    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}