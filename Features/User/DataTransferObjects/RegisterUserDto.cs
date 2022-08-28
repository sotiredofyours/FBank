using System.ComponentModel.DataAnnotations;

namespace FunctionalBank.WebApi.Features.User.DataTransferObjects;

public class RegisterUserDto
{
    /// <summary>
    /// User`s name.
    /// </summary>
    /// <example>Tony Stark</example>
    ///  [Required]
    [MaxLength(50)]
    [RegularExpression(@"^[\w\s]*$")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// User`s password.
    /// </summary>
    /// <example>superStrongPass123</example>
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    [RegularExpression(@"^[\w\s\d]*$")]
    public string Password { get; set; } = string.Empty;
}