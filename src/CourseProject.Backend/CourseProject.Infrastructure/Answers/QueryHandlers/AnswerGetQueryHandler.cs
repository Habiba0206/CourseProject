using AutoMapper;
using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Queries;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Answers.QueryHandlers;

public class AnswerGetQueryHandler(
    IMapper mapper,
    IAnswerService answerService)
    : IQueryHandler<AnswerGetQuery, ICollection<AnswerDto>>
{
    public async Task<ICollection<AnswerDto>> Handle(AnswerGetQuery request, CancellationToken cancellationToken)
    {
        var result = await answerService.Get(
            request.AnswerFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<AnswerDto>>(result);
    }
}
