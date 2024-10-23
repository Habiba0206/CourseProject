using AutoMapper;
using CourseProject.Application.Identity.Models;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Identity.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<SignInDetails, User>().ReverseMap();
        CreateMap<SignUpDetails, User>().ReverseMap();
    }
}
