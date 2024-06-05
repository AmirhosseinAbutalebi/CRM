using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetUserById
{
    public record GetUserByIdQuery(long Id) : IRequest<UserDto>;
}
