using FunctionalBank.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi;

internal class DatabaseContext : DbContext
{
    public DbSet<BankAccountEntity> BankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=FunctionalBank;User Id=user;Password=user");
}