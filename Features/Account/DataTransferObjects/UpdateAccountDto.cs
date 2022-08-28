using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.Features.Account.DataTransferObjects;

public class UpdateAccountDto
{
    /// <summary>
    /// Current balance on account.
    /// </summary>
    /// <example>RUB</example>
    [Required]
    public double Balance { get; set; }
    
}