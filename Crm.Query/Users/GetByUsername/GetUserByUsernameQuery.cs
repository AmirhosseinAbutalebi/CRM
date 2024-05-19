using Crm.Query.Users.DTOs;
using MediatR;
namespace Crm.Query.Users.GetByUsername
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="Username">string username </param>
    public record GetUserByUsernameQuery(string Username) : IRequest<UserDto>;
}
