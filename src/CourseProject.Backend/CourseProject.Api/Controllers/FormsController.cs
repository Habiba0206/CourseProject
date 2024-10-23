using CourseProject.Application.Forms.Commands;
using CourseProject.Application.Forms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FormGetQuery formGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(formGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{formId:guid}")]
    public async ValueTask<IActionResult> GetFormById([FromRoute] Guid formId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new FormGetByIdQuery { FormId = formId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateForm([FromBody] FormCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateForm([FromBody] FormUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{formId:guid}")]
    public async ValueTask<IActionResult> DeleteFormById([FromRoute] Guid formId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new FormDeleteByIdCommand { FormId = formId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
