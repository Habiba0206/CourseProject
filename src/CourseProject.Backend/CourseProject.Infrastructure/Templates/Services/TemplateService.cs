using CourseProject.Application.Templates.Models;
using CourseProject.Application.Templates.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Infrastructure.Templates.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Templates.Services;

public class TemplateService(
    ITemplateRepository templateRepository,
    TemplateValidator validator)
   : ITemplateService
{
    public IQueryable<Template> Get(
        Expression<Func<Template, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    templateRepository.Get(predicate, queryOptions);

    public IQueryable<Template> Get(
        TemplateFilter templateFilter,
        QueryOptions queryOptions = default) =>
    templateRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(templateFilter);

    public ValueTask<Template?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    templateRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Template>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    templateRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    templateRepository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Template> CreateAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(template);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return templateRepository.CreateAsync(template, commandOptions, cancellationToken);
    }

    public ValueTask<Template> UpdateAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(template);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return templateRepository.UpdateAsync(template, commandOptions, cancellationToken);
    }

    public ValueTask<Template?> DeleteAsync(
        Template template,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    templateRepository.DeleteAsync(template, commandOptions, cancellationToken);

    public ValueTask<Template?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    templateRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
