namespace FunctionalBank.WebApi.Features.Account.DataTransferObjects;

public class ReadAccountDto
{
    /// <summary>
    /// BankAccount id.
    /// </summary>
    /// <example>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Current balance on account.
    /// </summary>
    /// <example>100</example>
    public double Balance { get; set; }

    /// <summary>
    /// Currency of account
    /// </summary>
    /// <example>RUB</example>
    public string Currency { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }

}