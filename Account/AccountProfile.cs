using AutoMapper;
using FunctionalBank.WebApi.Account;

namespace FunctionalBank.WebApi.BankAccount;

public  class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountEntity, ReadAccountDto>();
        CreateMap<CreateAccountDto, AccountEntity>();
        CreateMap<UpdateAccountDto, AccountEntity>();
    }
}