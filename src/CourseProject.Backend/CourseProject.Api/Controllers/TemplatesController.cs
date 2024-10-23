using CourseProject.Application.Templates.Commands;
using CourseProject.Application.Templates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplatesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] TemplateGetQuery templateGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(templateGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{templateId:guid}")]
    public async ValueTask<IActionResult> GetTemplateById([FromRoute] Guid templateId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TemplateGetByIdQuery { TemplateId = templateId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateTemplate([FromBody] TemplateCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateTemplate([FromBody] TemplateUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{templateId:guid}")]
    public async ValueTask<IActionResult> DeleteTemplateById([FromRoute] Guid templateId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TemplateDeleteByIdCommand { TemplateId = templateId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
