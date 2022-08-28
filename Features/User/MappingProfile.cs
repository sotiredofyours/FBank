using AutoMapper;
using FunctionalBank.WebApi.Features.User.DataTransferObjects;
using FunctionalBank.WebApi.Features.User.Entity;
using FunctionalBank.WebApi.Features.User.Helpers;

namespace FunctionalBank.WebApi.Features.User;

internal class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, ReadUserDto>();
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<TokenPair, TokenPairDto>();
    }
}