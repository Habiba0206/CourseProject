using CourseProject.Application.Notifications.Models;
using CourseProject.Domain.Enums;
using FluentValidation;

namespace CourseProject.Infrastructure.Notifications.Validators;

public class EmailMessageValidator : AbstractValidator<EmailMessage>
{
    public EmailMessageValidator()
    {
        RuleSet(
            NotificationProcessingEvent.OnRendering.ToString(),
            () =>
            {
                RuleFor(history => history.Template).NotNull();
                RuleFor(history => history.Variables).NotNull();
                RuleFor(history => history.Template.Content).NotNull().NotEmpty();
            }
        );

        RuleSet(
            NotificationProcessingEvent.OnSending.ToString(),
            () =>
            {
                RuleFor(history => history.ReceiverEmailAddress).NotNull().NotEmpty();
                RuleFor(history => history.Subject).NotNull().NotEmpty();
                RuleFor(history => history.Body).NotNull().NotEmpty();
            }
        );
    }
}