using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetStatusTicketByUserIdReciver
{
    public record GetListOfCurrentTicketByUserIdReciverQuery(long UserId) : IRequest<List<TicketDto>>;
}
