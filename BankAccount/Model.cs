using System.ComponentModel.DataAnnotations.Schema;

namespace FunctionalBank.WebApi.Controllers;
[Table("account")]
public class AccountEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("balance")]
    public double Balance { get; set; }
    [Column("currency")]
    public string Currency { get; set; }
    [Column("created at")]
    public DateTime CreatedAt { get; set; }
}