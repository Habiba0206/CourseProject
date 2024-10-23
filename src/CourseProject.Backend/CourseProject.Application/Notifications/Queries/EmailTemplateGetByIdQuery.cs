using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Notifications.Queries;

public class EmailTemplateGetByIdQuery : IQuery<EmailTemplateDto?>
{
    public Guid EmailTemplateId { get; set; }
}
