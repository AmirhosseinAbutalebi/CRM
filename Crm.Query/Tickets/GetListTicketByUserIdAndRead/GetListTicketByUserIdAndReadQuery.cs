using Crm.Query.Tickets.DTOs;
using MediatR;

namespace Crm.Query.Tickets.GetListTicketByUserIdAndRead
{
    public record GetListTicketByUserIdAndReadQuery(long UserId) : IRequest<List<TicketDto>>;
}
