namespace FunctionalBank.WebApi.Features.User.DataTransferObjects;

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
    public string Username { get; set; } = String.Empty;
}