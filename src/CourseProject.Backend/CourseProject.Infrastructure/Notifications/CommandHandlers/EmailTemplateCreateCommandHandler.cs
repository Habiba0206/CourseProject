using AutoMapper;
using CourseProject.Application.Identity.Commands;
using CourseProject.Application.Identity.Models;
using CourseProject.Application.Identity.Services;
using CourseProject.Application.Notifications.Commands;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Infrastructure.Notifications.CommandHandlers;

public class EmailTemplateCreateCommandHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService) : ICommandHandler<EmailTemplateCreateCommand, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateCreateCommand request, CancellationToken cancellationToken)
    {
        var emailTemplate = mapper.Map<EmailTemplate>(request.EmailTemplateDto);

        var createdEmailTemplate = await emailTemplateService.CreateAsync(emailTemplate, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(createdEmailTemplate);
    }
}
