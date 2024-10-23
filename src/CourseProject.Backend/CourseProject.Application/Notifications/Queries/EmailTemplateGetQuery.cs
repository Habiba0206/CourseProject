using CourseProject.Application.Identity.Models;
using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Notifications.Queries;

public class EmailTemplateGetQuery : IQuery<ICollection<EmailTemplateDto>>
{
    public EmailTemplateFilter EmailTemplateFilter { get; set; }
}
