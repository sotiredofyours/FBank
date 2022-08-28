using System.Net.Mime;
using AutoMapper;
using FunctionalBank.WebApi.Features.Account.DataTransferObjects;
using FunctionalBank.WebApi.Features.Account.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunctionalBank.WebApi.Features.Account;

[ApiController]
[Authorize]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("/bankAccounts")]
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
    [Route("/all")]
    [ProducesResponseType(typeof(ReadAccountDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBankAccounts()
    {
        var subClaim = User.Claims.Single(claim => claim.Type == "sub");
        var userId = Guid.Parse(subClaim.Value);
        var bankAccounts = await _context.Accounts.Where(account => account.UserId == userId).ToListAsync();
        var readDtos = _mapper.Map<ICollection<ReadAccountDto>>(bankAccounts);
        return Ok(readDtos);
    }
    
    /// <summary>Create new bank account. </summary>
    /// <param name="createDto">Info of new bank account</param>
    /// <response code="198">Newly created bank account</response>
    [HttpPost]
    [ProducesResponseType(typeof(ReadAccountDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createDto)
    {
        var newBankAccount = _mapper.Map<AccountEntity>(createDto);
        var subClaim = User.Claims.Single(claim => claim.Type == "sub");
        newBankAccount.UserId = Guid.Parse(subClaim.Value);
        _context.Accounts.Add(newBankAccount);
        await _context.SaveChangesAsync();
        var readDto = _mapper.Map<ReadAccountDto>(newBankAccount);
        return Ok(readDto);
    }
    
    /// <summary>Update info of bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Account id.</param>
    /// <response code="204">Updated info of bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBankAccount([FromBody] UpdateAccountDto updatedAccount, [FromRoute]Guid id)
    {
        var oldBankAccount = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);

        if (oldBankAccount is null)
        {
            return NotFound();
        }

        oldBankAccount = _mapper.Map(updatedAccount, oldBankAccount);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    /// <summary>Delete bank account with matching id.</summary>
    /// <param name="id" example="xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx">Account id.</param>
    /// <response code="200">Deleted bank account.</response>
    /// <response code="404">Bank account with specified id was not found.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ReadAccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
    {
        var bankAccountToDelete
            = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);
        
        if (bankAccountToDelete is null)
        {
            return NotFound();
        }
        
        _context.Accounts.Remove(bankAccountToDelete);
        await _context.SaveChangesAsync();
        var readDto = _mapper.Map<ReadAccountDto>(bankAccountToDelete);
        return Ok(readDto);
    }
}