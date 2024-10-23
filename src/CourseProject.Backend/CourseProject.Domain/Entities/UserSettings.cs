using CourseProject.Domain.Enums;
using CourseProject.Domain.Common.Entities;

namespace CourseProject.Domain.Entities;

public class UserSettings : IEntity
{
    public NotificationType? PreferredNotificationType { get; set; } 

    /// <summary>
    ///     Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }
}