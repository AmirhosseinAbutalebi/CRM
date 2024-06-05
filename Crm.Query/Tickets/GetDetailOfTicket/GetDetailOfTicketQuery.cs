using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetDetailOfTicket
{
    public record GetDetailOfTicketQuery(long TicketId) : IRequest<TicketDto>;
}
