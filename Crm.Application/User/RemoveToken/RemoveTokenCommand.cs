using MediatR;

namespace Crm.Application.User.RemoveToken
{
    public record RemoveTokenCommand(long UserId, long TokenId) : IRequest<string>;
}
