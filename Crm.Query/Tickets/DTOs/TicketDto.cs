using Crm.Domain.TicketAgg.Enums;

namespace Crm.Query.Tickets.DTOs
{
    public class TicketDto
    {
        public long Id { get; set; }
        public long UserIdSender { get; set; }
        public long UserIdReciver { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public StatusTicket statusticket { get; set; }
    }
}
