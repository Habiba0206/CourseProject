using CourseProject.Domain.Entities;

namespace CourseProject.Application.Identity.Services;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}