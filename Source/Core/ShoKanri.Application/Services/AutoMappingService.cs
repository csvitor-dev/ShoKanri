using AutoMapper;
using ShoKanri.Domain.Entities;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.Services;
    public class AutoMappingService: Profile
    {
         public AutoMappingService()
    {
        RequestToDomain();
    }

    private void RequestToDomain() => 
        CreateMap<RegisterUserRequest, User>()
            .ForMember((dest) => dest.Password, (opt) => opt.Ignore());
    }