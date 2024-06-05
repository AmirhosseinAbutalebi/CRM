using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetListTicketByUserIdReciver
{
    public record GetListTicketByUserIdReciverQuery(long UserIdReciver) : IRequest<List<TicketDto>>;
}
