using AutoMapper;
using CourseProject.Application.Questions.Models;
using CourseProject.Application.Questions.Queries;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Questions.QueryHandlers;

public class QuestionGetByIdQueryHandler(
    IMapper mapper,
    IQuestionService questionService)
    : IQueryHandler<QuestionGetByIdQuery, QuestionDto>
{
    public async Task<QuestionDto> Handle(QuestionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await questionService.GetByIdAsync(request.QuestionId, cancellationToken: cancellationToken);

        return mapper.Map<QuestionDto>(result);
    }
}
