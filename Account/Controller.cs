using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi.Account;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("{id:guid}/bankAccounts")]
public class BankAccountController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;
    public BankAccountController(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>Retrieve all bank accounts. </summary>
    /// <response code="200">All bank accounts</response>
    
    [HttpGet]
 //   [Route("{id:guid}")]
    [ProducesResponseType(typeof(ReadAccountDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBankAccounts([FromRoute] Guid id)
    {
        var bankAccounts = await _context.BankAccounts.Where(account => account.User.Id == id).ToListAsync();
        var readDtos = _mapper.Map<ICollection<ReadAccountDto>>(bankAccounts);
        return Ok(readDtos);
    }
    
    /// <summary>Create new bank account. </summary>
    /// <param name="createDto">Info of new bank account</param>
    /// <response code="200">Newly created bank account</response>
    [HttpPost]
    [ProducesResponseType(typeof(ReadAccountDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createDto)
    {
        var newBankAccount = _mapper.Map<AccountEntity>(createDto);
        _context.BankAccounts.Add(newBankAccount);
        await _context.SaveChangesAsync();
        var readDto = _mapper.Map<ReadAccountDto>(newBankAccount);
        return Ok(readDto);
    }
    
    /// <summary>Update info of bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Meetup id.</param>
    /// <response code="204">Updated info of bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBankAccount([FromRoute] Guid id, [FromBody] UpdateAccountDto updatedAccount)
    {
        var oldBankAccount = await _context.BankAccounts.FirstOrDefaultAsync(meetup => meetup.Id == id);

        if (oldBankAccount is null)
        {
            return NotFound();
        }

        oldBankAccount = _mapper.Map(updatedAccount, oldBankAccount);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>Delete bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Meetup id.</param>
    /// <response code="200">Deleted bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpDelete]
    [ProducesResponseType(typeof(ReadAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
    {
        var bankAccountToDelete
            = await _context.BankAccounts.FirstOrDefaultAsync(meetup => meetup.Id == id);
        
        if (bankAccountToDelete is null)
        {
            return NotFound();
        }
        
        _context.BankAccounts.Remove(bankAccountToDelete);
        await _context.SaveChangesAsync();
        var readDto = _mapper.Map<ReadAccountDto>(bankAccountToDelete);
        return Ok(readDto);
    }
}