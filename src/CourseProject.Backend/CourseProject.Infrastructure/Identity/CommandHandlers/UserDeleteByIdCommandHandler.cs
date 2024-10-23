using CourseProject.Application.Identity.Commands;
using CourseProject.Application.Identity.Services;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Infrastructure.Identity.CommandHandlers;

public class UserDeleteByIdCommandHandler(
    IUserService userService)
    : ICommandHandler<UserDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(UserDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
