using AutoMapper;
using CourseProject.Application.Identity.Commands;
using CourseProject.Application.Identity.Models;
using CourseProject.Application.Identity.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Identity.CommandHandlers;

public class UserUpdateCommandHandler(
    IMapper mapper,
    IUserService userService) : ICommandHandler<UserUpdateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserDto);

        var updatedUser = await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(updatedUser);
    }
}
