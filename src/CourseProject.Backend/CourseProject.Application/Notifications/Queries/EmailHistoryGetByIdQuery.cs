using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Common.Queries;

namespace CourseProject.Application.Notifications.Queries;

public class EmailHistoryGetByIdQuery : IQuery<EmailHistoryDto?>
{
    public Guid EmailHistoryId { get; set; }
}
