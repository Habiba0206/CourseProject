using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Persistence.Caching.Brokers;
using CourseProject.Persistence.DataContexts;
using CourseProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories;

public class TemplateRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Template, AppDbContext>(appDbContext, cacheBroker),
    ITemplateRepository

{
    public IQueryable<Template> Get(
        Expression<Func<Template, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Template?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Template>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Template> CreateAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(template, commandOptions, cancellationToken);

    public ValueTask<Template> UpdateAsync(
        Template template,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(template, commandOptions, cancellationToken);

    public ValueTask<Template?> DeleteAsync(
        Template template,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(template, commandOptions, cancellationToken);

    public ValueTask<Template?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
