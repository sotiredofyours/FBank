using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.Controllers;

public class ReadBankAccountDto
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
    /// <summary>
    /// Date of bank account creation 
    /// </summary>
    /// <example>5/1/2008 8:30:52 AM</example>
    public DateTime CreatedAt { get; set; }
}

public class CreateBankAccountDto
{
    /// <summary>
    /// Currency of account
    /// </summary>
    /// <example>RUB</example>
    public double Balance { get; set; }
    
    /// <summary>
    /// Currency of account
    /// </summary>
    /// <example>RUB</example>
    public string Currency { get; set; }
    
    /// <summary>
    /// Date of bank account creation 
    /// </summary>
    /// <example>5/1/2008 8:30:52 AM</example>
    public DateTime CreatedAt { get; set; }
}

public class UpdateBankAccountDto
{
    /// <summary>
    /// Currency of account
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
    
    /// <summary>
    /// Date of bank account creation 
    /// </summary>
    /// <example>5/1/2008 8:30:52 AM</example>
    
    [Required]
    public DateTime CreatedAt { get; set; }
}