using CourseProject.Application.Questions.Commands;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Infrastructure.Questions.CommandHandlers;

public class QuestionDeleteByIdCommandHandler(
    IQuestionService questionService)
    : ICommandHandler<QuestionDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(QuestionDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await questionService.DeleteByIdAsync(request.QuestionId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
