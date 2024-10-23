using CourseProject.Domain.Entities;

namespace CourseProject.Application.Identity.Services;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}