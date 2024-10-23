using CourseProject.Application.Answers.Models;
using CourseProject.Application.Answers.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using CourseProject.Infrastructure.Answers.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Answers.Services;

public class AnswerService(
    IAnswerRepository answerRepository,
    AnswerValidator validator)
   : IAnswerService
{
    public IQueryable<Answer> Get(
        Expression<Func<Answer, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    answerRepository.Get(predicate, queryOptions);

    public IQueryable<Answer> Get(
        AnswerFilter answerFilter,
        QueryOptions queryOptions = default) =>
    answerRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(answerFilter);

    public ValueTask<Answer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Answer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    answerRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Answer> CreateAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            answer, 
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await answerRepository.CreateAsync(answer, commandOptions, cancellationToken);
    }

    public async ValueTask<Answer> UpdateAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            answer,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await answerRepository.UpdateAsync(answer, commandOptions, cancellationToken);
    }

    public ValueTask<Answer?> DeleteAsync(
        Answer answer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.DeleteAsync(answer, commandOptions, cancellationToken);

    public ValueTask<Answer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
