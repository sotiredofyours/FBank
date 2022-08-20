using System.Reflection;
using FunctionalBank.WebApi.Account;
using FunctionalBank.WebApi.User;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi;

public class DatabaseContext : DbContext
{
    public DbSet<AccountEntity> BankAccounts { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}