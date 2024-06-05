using Crm.Domain.TicketAgg.Enums;
using MediatR;

namespace Crm.Application.Ticket.CreateTicketDetail
{
    public class CreateTicketDetailCommand : IRequest
    {
        public CreateTicketDetailCommand(string text, long ticketSenderId, long ticketReciverId,
            StatusRead readTicket, StatusTicket statusTicket, long ticketId)
        {
            Text = text;
            TicketSenderId = ticketSenderId;
            TicketReciverId = ticketReciverId;
            ReadTicket = readTicket;
            StatusTicket = statusTicket;
            TicketId = ticketId;
        }
        public string Text { get; private set; }
        
        public long TicketSenderId { get; private set; }
       
        public long TicketReciverId { get; private set; }
        
        public StatusRead ReadTicket { get; private set; }
        
        public StatusTicket StatusTicket { get; private set; }
        
        public long TicketId { get; private set; }
    }
}
