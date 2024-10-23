using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Entities;

namespace CourseProject.Persistence.Repositories.Interfaces;

public interface IAccessTokenRepository
{
    ValueTask<AccessToken> CreateAsync(
        AccessToken accessToken,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default);
    ValueTask<AccessToken?> GetByIdAsync(
        Guid accessTokeId,
        CancellationToken cancellationToken = default);
    ValueTask<AccessToken> UpdateAsync(
        AccessToken accessToken,
        CancellationToken cancellationToken = default);
}
