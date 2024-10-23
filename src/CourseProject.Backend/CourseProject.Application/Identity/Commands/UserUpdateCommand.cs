using CourseProject.Application.Identity.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Identity.Commands;

public class UserUpdateCommand : ICommand<UserDto>
{
    public UserDto UserDto { get; set; }
}
