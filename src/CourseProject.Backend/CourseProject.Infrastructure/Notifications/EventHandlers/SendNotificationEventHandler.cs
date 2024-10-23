using AutoMapper;
using CourseProject.Application.Common.EventBus.Brokers;
using CourseProject.Application.Common.Settings;
using CourseProject.Application.Notifications.Events;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Events;
using CourseProject.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CourseProject.Infrastructure.Notifications.EventHandlers;

public class SendNotificationEventHandler(
    IServiceScopeFactory serviceScopeFactory,
    IMapper mapper,
    IOptions<NotificationSubscriberSettings> notificationSubscriberSettings,
    IEventBusBroker eventBusBroker,
    IOptions<NotificationSettings> notificationSettings
) : EventHandlerBase<SendNotificationEvent>
{
    protected override async ValueTask HandleAsync(SendNotificationEvent @event, CancellationToken cancellationToken)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var emailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();
        var emailHistoryService = scope.ServiceProvider.GetRequiredService<IEmailHistoryService>();

        if (@event.Message is EmailMessage emailMessage)
        {
            await emailSenderService.SendAsync(emailMessage, cancellationToken);

            var history = mapper.Map<EmailHistory>(emailMessage);
            history.SenderUserId = @event.SenderUserId;
            history.ReceiverUserId = @event.ReceiverUserId;

            Console.WriteLine($"TEMPLATE YES?: {history.TemplateId}");

            //await emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            if (!history.IsSuccessful) throw new InvalidOperationException("Email history is not created");
        }
    }
}
