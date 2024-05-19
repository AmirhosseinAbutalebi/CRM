using Crm.Domain.TicketDetailAgg.Enums;
namespace Crm.Query.TicketDetail.DTOs
{
    /// <summary>
    /// define dto for use in query
    /// </summary>
    public class TicketDetailDto
    {
        /// <summary>
        /// long id for ticketdetail dto
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// string text for ticketdetail text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// string TicketSender for user who send ticket
        /// </summary>
        public string TicketSender { get; set; }
        /// <summary>
        /// string TicketReciver for user who recive ticket
        /// </summary>
        public string TicketReciver { get; set; }
        /// <summary>
        /// statusread readticket for check ticket read or not
        /// </summary>
        public StatusRead ReadTicket { get; set; }
        /// <summary>
        /// statusticket statusticket for check ticket finish or not
        /// </summary>
        public StatusTicket StatusTicket { get; set; }
        /// <summary>
        /// long id for ticketid
        /// </summary>
        public long TicketId { get; set; }
        /// <summary>
        /// string FullNameSender for show name not username in page
        /// </summary> 
        public string FullNameSender { get; set; }
        /// <summary>
        /// string FullNameReciver for show name not user name in page
        /// </summary>
        public string FullNameReciver { get; set; }
    }
}
