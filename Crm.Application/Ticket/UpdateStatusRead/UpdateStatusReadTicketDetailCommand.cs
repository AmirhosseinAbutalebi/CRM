using MediatR;

namespace Crm.Application.Ticket.UpdateStatusRead
{
    public class UpdateStatusReadTicketDetailCommand : IRequest
    {
        public UpdateStatusReadTicketDetailCommand(long ticketId, long ticketReciverId)
        {
            TicketId = ticketId;
            TicketReciverId = ticketReciverId;
        }
        public long TicketId { get; private set; }
        
        public long TicketReciverId { get; private set; }
    }
}
