using AutoMapper;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Queries;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetByIdQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetByIdQuery, EmailHistoryDto>
{
    public async Task<EmailHistoryDto> Handle(EmailHistoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.GetByIdAsync(request.EmailHistoryId, cancellationToken: cancellationToken);

        return mapper.Map<EmailHistoryDto>(result);
    }
}
