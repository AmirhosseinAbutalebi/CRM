using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetUsers
{
    public record GetUsersQuery : IRequest<List<UserDto>>;
}
