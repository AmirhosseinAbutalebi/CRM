using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetStatusTicketByUserId
{
    public record GetListOfFinishedTicketByUserIdQuery(long UserId) : IRequest<List<TicketDto>>;
}
