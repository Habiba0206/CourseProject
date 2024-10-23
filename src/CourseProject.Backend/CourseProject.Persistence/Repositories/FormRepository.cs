using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Persistence.Caching.Brokers;
using CourseProject.Persistence.DataContexts;
using CourseProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories;

public class FormRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Form, AppDbContext>(appDbContext, cacheBroker),
    IFormRepository

{
    public IQueryable<Form> Get(
        Expression<Func<Form, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Form?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Form>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Form> CreateAsync(
        Form form,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(form, commandOptions, cancellationToken);

    public ValueTask<Form> UpdateAsync(
        Form form,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(form, commandOptions, cancellationToken);

    public ValueTask<Form?> DeleteAsync(
        Form form,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(form, commandOptions, cancellationToken);

    public ValueTask<Form?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
