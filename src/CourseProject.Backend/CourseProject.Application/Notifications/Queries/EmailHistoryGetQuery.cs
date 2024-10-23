using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Notifications.Queries;

public class EmailHistoryGetQuery : IQuery<ICollection<EmailHistoryDto>>
{
    public EmailHistoryFilter EmailHistoryFilter { get; set; }
}
