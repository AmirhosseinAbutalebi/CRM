using Crm.Domain.Shared;
using Crm.Domain.TicketAgg.Enums;

namespace Crm.Domain.TicketAgg
{
    public class TicketDetail : BaseEntity
    {
        public TicketDetail(string text, long ticketSenderId, long ticketReciverId,
            StatusRead readTicket, StatusTicket statusTicket, long ticketId)
        {
            Text = text;
            TicketSenderId = ticketSenderId;
            TicketReciverId = ticketReciverId;
            ReadTicket = readTicket;
            StatusTicket = statusTicket;
            TicketsId = ticketId;
        }
        private TicketDetail()
        {

        }
        public string Text { get; private set; }
        
        public long TicketSenderId { get; private set; }
        
        public long TicketReciverId { get; private set; }
        
        public StatusRead ReadTicket { get; private set; }
        
        public StatusTicket StatusTicket { get; private set; }
        
        public long TicketsId { get; private set; }

        public void ChangeStatusRead(StatusRead statusRead)
        {
            ReadTicket = statusRead;
        }
    }
}
