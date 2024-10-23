using AutoMapper;
using CourseProject.Application.Identity.Models;
using CourseProject.Application.Identity.Queries;
using CourseProject.Application.Identity.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Identity.QueryHandlers;

public class UserGetByIdQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(result);
    }
}
