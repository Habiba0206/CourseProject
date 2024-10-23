using AutoMapper;
using CourseProject.Application.Questions.Models;
using CourseProject.Application.Questions.Queries;
using CourseProject.Application.Questions.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Questions.QueryHandlers;

public class QuestionGetQueryHandler(
    IMapper mapper,
    IQuestionService questionService)
    : IQueryHandler<QuestionGetQuery, ICollection<QuestionDto>>
{
    public async Task<ICollection<QuestionDto>> Handle(QuestionGetQuery request, CancellationToken cancellationToken)
    {
        var result = await questionService.Get(
            request.QuestionFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<QuestionDto>>(result);
    }
}
