using AutoMapper;

namespace FunctionalBank.WebApi.User;

internal class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, ReadUserDto>();
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<JwtTokenHelper.TokenPair, TokenPairDto>();
    }
}