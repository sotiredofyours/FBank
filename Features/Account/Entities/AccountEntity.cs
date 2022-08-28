namespace FunctionalBank.WebApi.Features.Account.Entities;

public class AccountEntity
{
    public Guid Id { get; set; }
    public double Balance { get; set; }
    public string Currency { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}