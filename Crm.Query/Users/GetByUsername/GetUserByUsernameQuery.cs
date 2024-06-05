using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetByUsername
{
    public record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
}
