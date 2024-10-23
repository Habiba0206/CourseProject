using CourseProject.Application.Answers.Models;
using CourseProject.Application.Forms.Models;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using System.Linq.Expressions;

namespace CourseProject.Application.Forms.Services;

public interface IFormService
{
    IQueryable<Form> Get(
             Expression<Func<Form, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Form> Get(
        FormFilter formFilter,
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
