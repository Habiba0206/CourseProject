using CourseProject.Application.Identity.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Identity.Queries;

public class UserGetQuery : IQuery<ICollection<UserDto>>
{
    public UserFilter UserFilter { get; set; }
}
