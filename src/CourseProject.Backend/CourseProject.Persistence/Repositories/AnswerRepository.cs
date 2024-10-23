using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Persistence.Caching.Brokers;
using CourseProject.Persistence.DataContexts;
using CourseProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Security.Claims;

namespace CourseProject.Persistence.Repositories;

public class AnswerRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Answer, AppDbContext>(appDbContext, cacheBroker),
    IAnswerRepository

{
    public IQueryable<Answer> Get(
        Expression<Func<Answer, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Answer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Answer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Answer> CreateAsync(
    Answer asnwer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(asnwer, commandOptions, cancellationToken);

    public ValueTask<Answer> UpdateAsync(
        Answer answer,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(answer, commandOptions, cancellationToken);

    public ValueTask<Answer?> DeleteAsync(
        Answer answer,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(answer, commandOptions, cancellationToken);

    public ValueTask<Answer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
