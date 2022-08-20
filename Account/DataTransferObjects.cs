using System.ComponentModel.DataAnnotations;
using FunctionalBank.WebApi.User;

namespace FunctionalBank.WebApi.Account;

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
    public string Currency { get; set; }
    
    public UserEntity User { get; set; }

}

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
    public string Currency { get; set; }
    [Required]
    public UserEntity User { get; set; }

}

public class UpdateAccountDto
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
    public string Currency { get; set; }
    

}