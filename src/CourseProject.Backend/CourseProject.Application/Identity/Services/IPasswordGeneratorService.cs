using CourseProject.Domain.Entities;

namespace CourseProject.Application.Identity.Services;

public interface IPasswordGeneratorService
{
    string GeneratePassword();

    string GetValidatedPassword(string password, User user);
}