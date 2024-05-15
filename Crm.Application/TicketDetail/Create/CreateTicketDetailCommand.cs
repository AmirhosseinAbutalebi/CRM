
using Crm.Domain.TicketDetailAgg.Enums;
using MediatR;

namespace Crm.Application.TicketDetail.Create
{
    /// <summary>
    /// this class define for set data needed in command CreateTicketDetail
    /// we use mediatR and DesignPattern mediator thus need inhert IRequest there
    /// </summary>
    public class CreateTicketDetailCommand : IRequest
    {
        /// <summary>
        /// contructor CreateTicketCommand for set value in property
        /// </summary>
        /// <param name="text">string text</param>
        /// <param name="ticketSender">string ticketSender who send ticket</param>
        /// <param name="ticketReciver">string ticketReciver who recive ticket</param>
        /// <param name="readTicket">enum statusread readticket</param>
        /// <param name="statusTicket">enum statusticket statusticket</param>
        /// <param name="ticketId">long ticketid</param>
        public CreateTicketDetailCommand(string text, string ticketSender, string ticketReciver,
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
        /// property Text type string with private set (just readonly)
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// property TicketSender type string with private set (just readonly)
        /// </summary>
        public string TicketSender { get; private set; }
        /// <summary>
        /// property TicketReciver type string with private set (just readonly)
        /// </summary>
        public string TicketReciver { get; private set; }
        /// <summary>
        /// property ReadTicket type StatusRead with private set (just readonly)
        /// </summary>
        public StatusRead ReadTicket { get; private set; }
        /// <summary>
        /// property StatusTicket type StatusTicket with private set (just readonly)
        /// </summary>
        public StatusTicket StatusTicket { get; private set; }
        /// <summary>
        /// property TicketId type long with private set (just readonly)
        /// </summary>
        public long TicketId { get; private set; }
    }
}
