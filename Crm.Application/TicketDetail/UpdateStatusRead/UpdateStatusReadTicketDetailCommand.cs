using MediatR;

namespace Crm.Application.TicketDetail.UpdateStatusRead
{
    public class UpdateStatusReadTicketDetailCommand : IRequest
    {
        /// <summary>
        /// contructor CreateTicketCommand for set value in property
        /// </summary>
        /// <param name="ticketId">long ticketid</param>
        /// <param name="ticketSender">string ticketSender</param>
        public UpdateStatusReadTicketDetailCommand(long ticketId, string ticketSender)
        {
            TicketId = ticketId;
            TicketSender = ticketSender;
        }
        /// <summary>
        /// property TicketId type long with private set (just readonly)
        /// </summary>
        public long TicketId { get; private set; }
        /// <summary>
        /// property TicketSender type string with private set (just readonly)
        /// </summary>
        public string TicketSender { get; private set; }
    }
}
