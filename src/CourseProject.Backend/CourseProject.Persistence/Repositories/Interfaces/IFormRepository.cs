using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories.Interfaces;

public interface IFormRepository
{
    IQueryable<Form> Get(
             Expression<Func<Form, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<Form?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Form>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Form> CreateAsync(
        Form form,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Form> UpdateAsync(
        Form form,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Form?> DeleteAsync(
        Form form,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Form?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
