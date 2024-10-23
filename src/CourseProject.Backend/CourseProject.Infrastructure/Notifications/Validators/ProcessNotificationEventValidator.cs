using CourseProject.Application.Notifications.Events;
using FluentValidation;

namespace CourseProject.Infrastructure.Notifications.Validators;

public class ProcessNotificationEventValidator : AbstractValidator<ProcessNotificationEvent>
{
    public ProcessNotificationEventValidator()
    {
        RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);
    }
}