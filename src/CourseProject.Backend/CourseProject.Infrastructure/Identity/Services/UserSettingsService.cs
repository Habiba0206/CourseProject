using CourseProject.Application.Identity.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Persistence.Repositories.Interfaces;

namespace CourseProject.Infrastructure.Identity.Services;

public class UserSettingsService(IUserSettingsRepository userSettingsRepository) : IUserSettingsService
{
    public ValueTask<UserSettings?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
    userSettingsRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<UserSettings> CreateAsync(
        UserSettings userSettings, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
    userSettingsRepository.CreateAsync(userSettings, commandOptions, cancellationToken);
}
