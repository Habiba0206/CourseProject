using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Persistence.Caching.Brokers;
using CourseProject.Persistence.DataContexts;
using CourseProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace CourseProject.Persistence.Repositories;

public class UserRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<User, AppDbContext>(appDbContext, cacheBroker),
    IUserRepository

{
    public IQueryable<User> Get(
        Expression<Func<User, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<User?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<User> CreateAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(user, commandOptions, cancellationToken);

    public ValueTask<User> UpdateAsync(
        User user,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(user, commandOptions, cancellationToken);

    public ValueTask<User?> DeleteAsync(
        User user,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(user, commandOptions, cancellationToken);

    public ValueTask<User?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
