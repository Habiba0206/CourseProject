using CourseProject.Application.Answers.Commands;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Infrastructure.Answers.CommandHandlers;

public class AnswerDeleteByIdCommandHandler(
    IAnswerService answerService)
    : ICommandHandler<AnswerDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(AnswerDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await answerService.DeleteByIdAsync(request.AnswerId, cancellationToken: cancellationToken);

        return result is not null;
    }
}