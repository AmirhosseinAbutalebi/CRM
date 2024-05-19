using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetUserById
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    public record GetUserByIdQuery(long Id) : IRequest<UserDto>;
}
