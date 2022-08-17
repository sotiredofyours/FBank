namespace FunctionalBank.WebApi.Controllers;
internal class BankAccountEntity
{
    public Guid Id { get; set; }
    public double Balance { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
}