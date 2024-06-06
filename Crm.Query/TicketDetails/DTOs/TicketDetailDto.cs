using Crm.Domain.TicketAgg.Enums;

namespace Crm.Query.TicketDetail.DTOs
{
    public class TicketDetailDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long TicketSenderId { get; set; }
        public long TicketReciverId { get; set; }
        public StatusRead ReadTicket { get; set; }
        public StatusTicket StatusTicket { get; set; }
        public long TicketId { get; set; }
        public string? FullNameSender { get; set; }
        public string? FullNameReciver { get; set; }
    }
}
