using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetListTicketByUserId
{
    public record GetListTicketByUserIdQuery(long UserId) : IRequest<List<TicketDto>>;
}
