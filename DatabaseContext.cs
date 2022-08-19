using FunctionalBank.WebApi.Controllers;
using FunctionalBank.WebApi.User;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi;

public class DatabaseContext : DbContext
{
    public DbSet<AccountEntity> BankAccounts { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }
}