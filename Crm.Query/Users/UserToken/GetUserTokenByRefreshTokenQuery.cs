using Crm.Query.Users.DTOs;
using MediatR;

namespace Crm.Query.Users.UserToken
{
    public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IRequest<UserTokenDto>;
}
