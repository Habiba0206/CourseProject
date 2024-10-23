using AutoMapper;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Queries;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Answers.QueryHandlers;

public class AnswerGetByIdQueryHandler(
    IMapper mapper,
    IAnswerService answerService)
    : IQueryHandler<AnswerGetByIdQuery, AnswerDto>
{
    public async Task<AnswerDto> Handle(AnswerGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await answerService.GetByIdAsync(request.AnswerId, cancellationToken: cancellationToken);

        return mapper.Map<AnswerDto>(result);
    }
}
