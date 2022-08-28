using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.Features.Account.DataTransferObjects;

public class CreateAccountDto
{
    /// <summary>
    /// Current balance on account.
    /// </summary>
    /// <example>RUB</example>
    [Required]
    public double Balance { get; set; }

    /// <summary>
    /// Currency of account
    /// </summary>
    /// <example>RUB</example>
    [Required]
    public string Currency { get; set; } = string.Empty;

}