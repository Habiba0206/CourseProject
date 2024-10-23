using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] AnswerGetQuery answerGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(answerGetQuery, cancellationToken);
        
        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{answerId:guid}")]
    public async ValueTask<IActionResult> GetAnswerById([FromRoute] Guid answerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new AnswerGetByIdQuery { AnswerId = answerId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAnswer([FromBody] AnswerCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAnswer([FromBody] AnswerUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{answerId:guid}")]
    public async ValueTask<IActionResult> DeleteAnswerById([FromRoute] Guid answerId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new AnswerDeleteByIdCommand { AnswerId = answerId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
