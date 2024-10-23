using CourseProject.Application.Answers.Models;
using CourseProject.Application.Notifications.Models;
using CourseProject.Application.Notifications.Services;
using CourseProject.Domain.Common.Commands;
using CourseProject.Domain.Common.Queries;
using CourseProject.Domain.Entities;
using CourseProject.Domain.Enums;
using CourseProject.Infrastructure.Notifications.Validators;
using CourseProject.Persistence.Extensions;
using CourseProject.Persistence.Repositories;
using CourseProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseProject.Infrastructure.Notifications.Services;

public class EmailTemplateService(
    IEmailTemplateRepository emailTemplateRepository,
    EmailTemplateValidator emailTemplateValidator) :
    IEmailTemplateService
{
    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
    emailTemplateRepository.CheckByIdAsync(id, cancellationToken);

    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
    emailTemplateRepository.Get(predicate, queryOptions);

    public IQueryable<EmailTemplate> Get(
        EmailTemplateFilter emailTemplateFilter, 
        QueryOptions queryOptions = default) =>
    emailTemplateRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(emailTemplateFilter);

    public ValueTask<EmailTemplate?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
    emailTemplateRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<EmailTemplate>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
    emailTemplateRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public async ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
    await emailTemplateRepository
        .Get(template => template.TemplateType == templateType, queryOptions)
            .SingleOrDefaultAsync(cancellationToken);

    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
    {
        var validationResult = emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return emailTemplateRepository.CreateAsync(emailTemplate, commandOptions, cancellationToken);
    }
}
