using AutoMapper;
using CourseProject.Application.Identity.Models;
using CourseProject.Application.Identity.Queries;
using CourseProject.Application.Identity.Services;
using CourseProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Infrastructure.Identity.QueryHandlers;

public class UserGetQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetQuery, ICollection<UserDto>>
{
    public async Task<ICollection<UserDto>> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.Get(
            request.UserFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<UserDto>>(result);
    }
}
