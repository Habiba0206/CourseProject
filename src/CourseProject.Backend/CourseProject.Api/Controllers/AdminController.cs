using CourseProject.Application.Identity.Commands;
using CourseProject.Application.Identity.Models;
using CourseProject.Application.Templates.Commands;
using CourseProject.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController(IMediator mediator) : ControllerBase
{
    [HttpPost("users/{userId}/block")]
    public async ValueTask<IActionResult> BlockUser([FromRoute]Guid userId, CancellationToken cancellationToken)
    {
        var user = new UserDto { Id = userId, UserState = UserState.Blocked };
        var command = new UserUpdateCommand { UserDto = user };

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPost("users/{userId}/unblock")]
    public async ValueTask<IActionResult> UnblockUser([FromRoute]Guid userId, CancellationToken cancellationToken)
    {
        var user = new UserDto { Id = userId, UserState = UserState.Blocked };
        var command = new UserUpdateCommand { UserDto = user };

        await mediator.Send(command, cancellationToken);
        
        return Ok();
    }

    [HttpPost("users/{userId}/makeAdmin")]
    public async ValueTask<IActionResult> MakeUserAdmin([FromRoute]Guid userId, CancellationToken cancellationToken)
    {
        var user = new UserDto { Id = userId, Role = Role.Admin };
        var command = new UserUpdateCommand { UserDto = user };

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPost("templates")]
    public async ValueTask<IActionResult> CreateTemplate([FromBody] TemplateCreateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }
}
