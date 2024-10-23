using CourseProject.Application.Forms.Models;
using CourseProject.Application.Forms.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Infrastructure.Forms.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Forms.Services;

public class FormService(
    IFormRepository answerRepository,
    FormValidator validator)
   : IFormService
{
    public IQueryable<Form> Get(
        Expression<Func<Form, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    answerRepository.Get(predicate, queryOptions);

    public IQueryable<Form> Get(
        FormFilter answerFilter,
        QueryOptions queryOptions = default) =>
    answerRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(answerFilter);

    public ValueTask<Form?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Form>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    answerRepository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Form> CreateAsync(
        Form answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(answer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return answerRepository.CreateAsync(answer, commandOptions, cancellationToken);
    }

    public ValueTask<Form> UpdateAsync(
        Form answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(answer);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return answerRepository.UpdateAsync(answer, commandOptions, cancellationToken);
    }

    public ValueTask<Form?> DeleteAsync(
        Form answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.DeleteAsync(answer, commandOptions, cancellationToken);

    public ValueTask<Form?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
