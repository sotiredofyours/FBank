using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.User;

public class ReadUserDto
{
    /// <summary>
    /// User id.
    /// </summary>
    /// <example>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// User`s name.
    /// </summary>
    /// <example>Tony Stark</example>
    public string Username { get; set; }
}

public class RegisterUserDto
{
    
    /// <summary>
    /// User`s name.
    /// </summary>
    /// <example>Tony Stark</example>
    ///  [Required]
    [MaxLength(50)]
    [RegularExpression(@"^[\w\s]*$")]
    public string Username { get; set; }
    /// <summary>
    /// User`s password.
    /// </summary>
    /// <example>superStrongPass123</example>
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    [RegularExpression(@"^[\w\s\d]*$")]
    public string Password { get; set; }
}