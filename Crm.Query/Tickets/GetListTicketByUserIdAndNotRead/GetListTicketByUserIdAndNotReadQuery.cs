using Crm.Query.Tickets.DTOs;
using MediatR;

namespace Crm.Query.Tickets.GetListTicketByUserIdAndNotRead
{
    public record GetListTicketByUserIdAndNotReadQuery(long UserId) : IRequest<List<TicketDto>>;
}
