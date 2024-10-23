using CourseProject.Domain.Enums;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Notifications.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}