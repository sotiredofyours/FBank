using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi.User;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class Controller : ControllerBase
{
    private readonly DatabaseContext _context;

    public Controller(DatabaseContext context) => _context = context;
    
    
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="registerDto">User registration information.</param>
    /// <response code="200">Newly crated user</response>
    /// <response code="409">Failed to register a user: username already taken.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ReadUserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserDto registerDto)
    {
        var newUser = new UserEntity
        {
            Id = Guid.NewGuid(),
            Username = registerDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
        };
        var usernameTaken = await _context.Users.AnyAsync(x => x.Username == registerDto.Username);
        if (usernameTaken)
        {
            return Conflict("Username already exist");
        }
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        var readDto = new ReadUserDto
        {
            Username = newUser.Username,
            Id = newUser.Id
        };
        return Ok(readDto);
    }
}