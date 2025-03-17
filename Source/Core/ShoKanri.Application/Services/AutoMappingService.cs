using AutoMapper;
using ShoKanri.Domain.Entities;
using ShoKanri.Http.Dto;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.Services;
public class AutoMappingService : Profile
{
    public AutoMappingService()
    {
        CreateMap<RegisterUserRequest, User>()
            .ForMember((dest) => dest.Password, (opt) => opt.Ignore());
        CreateMap<User, RegisterUserResponse>();

        CreateMap<LoginUserRequest, User>()
            .ForMember((dest) => dest.Password, (opt) => opt.Ignore());
        CreateMap<User, LoginUserDto>();
    }
}