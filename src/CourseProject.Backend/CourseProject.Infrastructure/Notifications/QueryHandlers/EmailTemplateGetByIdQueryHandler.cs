using AutoMapper;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Queries;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Queries;
using CourseProject.Infrastructure.Notifications.Services;

namespace CourseProject.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetByIdQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetByIdQuery, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.GetByIdAsync(request.EmailTemplateId, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(result);
    }
}

