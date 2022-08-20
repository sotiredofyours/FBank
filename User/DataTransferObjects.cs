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

public class AuthenticateUserDto
{
    /// <summary>Username for authentication.</summary>
    /// <example>tony_lore</example>
    [Required]
    public string Username { get; set; }
    
    /// <summary>Password for authentication.</summary>
    /// <example>password123</example>
    [Required]
    public string Password { get; set; }
}

public class TokenPairDto
{
    /// <summary>JWT Access Token.</summary>
    /// <example>header.payload.signature</example>
    public string AccessToken { get; set; }
    
    /// <summary>JWT Refresh Token.</summary>
    /// <example>header.payload.signature</example>
    public string RefreshToken { get; set; }
}