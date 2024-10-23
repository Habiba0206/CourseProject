using CourseProject.Application.Identity.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Identity.Queries;

public class UserGetByIdQuery : IQuery<UserDto?>
{
    public Guid UserId { get; set; }
}
