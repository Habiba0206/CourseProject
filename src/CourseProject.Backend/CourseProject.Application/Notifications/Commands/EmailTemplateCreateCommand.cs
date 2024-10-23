using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Commands;

namespace CourseProject.Application.Notifications.Commands;

public class EmailTemplateCreateCommand : ICommand<EmailTemplateDto>
{
    public EmailTemplateDto EmailTemplateDto { get; set; }
}
