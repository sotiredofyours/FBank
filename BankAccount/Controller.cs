using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi.Controllers;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("/bankAccounts")]
public class BankAccountController : ControllerBase
{
    private readonly DatabaseContext _context = new();
    
    /// <summary>Retrieve all bank accounts. </summary>
    /// <response code="200">All bank accounts</response>
    
    [HttpGet]
    [ProducesResponseType(typeof(ReadBankAccountDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBankAccounts()
    {
        var bankAccounts = await _context.BankAccounts.ToListAsync();
        var readDtos = bankAccounts.Select(bankAccount => new ReadBankAccountDto()
        {
            Id = bankAccount.Id,
            Currency = bankAccount.Currency,
            Balance = bankAccount.Balance,
            CreatedAt = bankAccount.CreatedAt
        });

        return Ok(readDtos);
    }
    
    /// <summary>Create new bank account. </summary>
    /// <param name="createDto">Info of new bank account</param>
    /// <response code="200">Newly created bank account</response>
    [HttpPost]
    [ProducesResponseType(typeof(ReadBankAccountDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateMeetup([FromBody] CreateBankAccountDto createDto)
    {
        var newBankAccount = new BankAccountEntity
        {
            Id = new Guid(),
            Balance = createDto.Balance,
            Currency = createDto.Currency,
            CreatedAt = createDto.CreatedAt
        };
        _context.BankAccounts.Add(newBankAccount);
        await _context.SaveChangesAsync();

        var readDto = new ReadBankAccountDto
        {
            Id = newBankAccount.Id,
            Balance = newBankAccount.Balance,
            Currency = newBankAccount.Currency,
            CreatedAt = newBankAccount.CreatedAt
        };
        
        return Ok(readDto);
    }
    
    
    /// <summary>Update info of bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Meetup id.</param>
    /// <response code="204">Updated info of bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBankAccount([FromRoute] Guid id, [FromBody] UpdateBankAccountDto updatedMeetup)
    {
        var oldBankAccount = await _context.BankAccounts.FirstOrDefaultAsync(meetup => meetup.Id == id);

        if (oldBankAccount is null)
        {
            return NotFound();
        }

        oldBankAccount.Balance = updatedMeetup.Balance;
        oldBankAccount.Currency = updatedMeetup.Currency;
        oldBankAccount.CreatedAt = updatedMeetup.CreatedAt;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>Delete bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Meetup id.</param>
    /// <response code="200">Deleted bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ReadBankAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMeetup([FromRoute] Guid id)
    {
        var bankAccountToDelete
            = await _context.BankAccounts.FirstOrDefaultAsync(meetup => meetup.Id == id);
        
        if (bankAccountToDelete is null)
        {
            return NotFound();
        }
        
        _context.BankAccounts.Remove(bankAccountToDelete);
        await _context.SaveChangesAsync();
        var readDto = new ReadBankAccountDto
        {
            Id = bankAccountToDelete.Id,
            Balance = bankAccountToDelete.Balance,
            Currency = bankAccountToDelete.Currency,
            CreatedAt = bankAccountToDelete.CreatedAt
        };
        
        return Ok(readDto);
    }
}