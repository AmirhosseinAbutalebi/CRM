using Crm.Domain.Shared;
using Crm.Domain.TicketDetailAgg.Enums;

namespace Crm.Domain.TicketDetailAgg
{
    /// <summary>
    /// this class is root and for define entity ticketDetail
    /// we dont have essential method and this project is basic
    /// then we dont have mehtod in this domain
    /// </summary>
    public class TicketDetail : AggregateRoot
    {
        /// <summary>
        /// constructor of TicketDetail for set value for properties
        /// that define readonly
        /// </summary>
        /// <param name="text">Text that use in ticket detail</param>
        /// <param name="ticketSender">person who send ticket</param>
        /// <param name="ticketReciver">person who recive ticket</param>
        /// <param name="readTicket">show us this ticket read or not</param>
        /// <param name="statusTicket">show us this ticket has status finish or not</param>
        /// <param name="ticketId">ticketid with type long</param>
        public TicketDetail(string text, string ticketSender, string ticketReciver,
            StatusRead readTicket, StatusTicket statusTicket, long ticketId)
        {
            Text = text;
            TicketSender = ticketSender;
            TicketReciver = ticketReciver;
            ReadTicket = readTicket;
            StatusTicket = statusTicket;
            TicketId = ticketId;
        }
        /// <summary>
        /// need to define second constructor for Entity framework
        /// </summary>
        private TicketDetail()
        {
            
        }
        /// <summary>
        /// property Text for text of ticketdetail and just readonly (private set)
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// property Ticketsender that show person who send ticket and just readonly (private set)
        /// </summary>
        public string TicketSender { get; private set; }
        /// <summary>
        /// property TicketReciver that show person who recive ticket and just readonly (private set)
        /// </summary>
        public string TicketReciver { get; private set; }
        /// <summary>
        /// property ReadTicket that show us ticket read or not and just readonly (private set)
        /// </summary>
        public StatusRead ReadTicket { get; private set; }
        /// <summary>
        /// property StatusTicket that show us status ticket and just readonly (private set)
        /// </summary>
        public StatusTicket StatusTicket { get; private set; }
        /// <summary>
        /// property TicketId and just readonly (private set)
        /// </summary>
        public long TicketId { get; private set; }

        public void ChangeStatusRead(StatusRead statusRead)
        {
            ReadTicket = statusRead;
        }
    }
}
