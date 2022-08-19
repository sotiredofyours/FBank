using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi.User;
[Index(nameof(Username), IsUnique = true)]
[Table("users")]
public class UserEntity
{
    [Column("id")] 
    public Guid Id { get; set; }
    
    [Column("username")]
    public string Username { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
}