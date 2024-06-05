using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetStatusTicketByUserId
{
    public record GetListOfCurrentTicketByUserIdQuery(long UserId): IRequest<List<TicketDto>>;
}
