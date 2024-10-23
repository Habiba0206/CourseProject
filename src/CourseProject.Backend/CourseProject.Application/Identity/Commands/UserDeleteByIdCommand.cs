using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Identity.Commands;

public class UserDeleteByIdCommand : ICommand<bool>
{
    public Guid UserId { get; set; }
}
