using Crm.Query.Users.DTOs;
using MediatR;

namespace Crm.Query.Users.UserToken.GetUserByToken
{
    public record GetUserByJwtTokenQuery(string HashJwtToken):IRequest<UserTokenDto>;
}
