using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using CourseProject.Infrastructure.Notifications.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Notifications.Services;

public class EmailHistoryService(
    IEmailHistoryRepository emailHistoryRepository,
    EmailHistoryValidator emailHistoryValidator)
    : IEmailHistoryService
{
    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.CheckByIdAsync(id, cancellationToken);

    public IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
    emailHistoryRepository.Get(predicate, queryOptions);

    public IQueryable<EmailHistory> Get(
        EmailHistoryFilter emailHistoryFilter, 
        QueryOptions queryOptions = default) =>
    emailHistoryRepository.
        Get(queryOptions: queryOptions)
        .ApplyPagination(emailHistoryFilter);

    public ValueTask<EmailHistory?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default,  
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.GetByIdAsync(id, queryOptions);

    public ValueTask<IList<EmailHistory>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.GetByIdsAsync(ids, queryOptions);

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var validationResult = await emailHistoryValidator.ValidateAsync(
            emailHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken
        );
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await emailHistoryRepository.CreateAsync(emailHistory, commandOptions, cancellationToken);
    }
}
