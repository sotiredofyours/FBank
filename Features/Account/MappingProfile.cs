using AutoMapper;
using FunctionalBank.WebApi.Features.Account.DataTransferObjects;
using FunctionalBank.WebApi.Features.Account.Entities;

namespace FunctionalBank.WebApi.Features.Account;

public  class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<AccountEntity, ReadAccountDto>();
        CreateMap<CreateAccountDto, AccountEntity>();
        CreateMap<UpdateAccountDto, AccountEntity>();
    }
}