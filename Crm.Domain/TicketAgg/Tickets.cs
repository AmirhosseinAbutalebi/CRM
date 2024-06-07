using Crm.Domain.Shared;
using Crm.Domain.TicketAgg.Enums;

namespace Crm.Domain.TicketAgg
{
    public class Tickets : AggregateRoot
    {
        public Tickets(long userIdSender, long userIdReciver, string title, string description)
        {
            UserIdSender = userIdSender;
            UserIdReciver = userIdReciver;
            Title = title;
            Description = description;
            Items = new List<TicketDetail>();
        }
        public Tickets()
        {
            
        }
        public long UserIdSender { get; private set; }
        
        public long UserIdReciver { get; private set; }
        
        public string Title { get; private set; }
        
        public string Description { get; private set; }

        public ICollection<TicketDetail> Items { get; }

        public StatusTicket StatusTicket { get; private set; }

        public void ChangeStatusTicket(StatusTicket statusTicket)
        {
            StatusTicket = statusTicket;
        }
        public void AddticketDetail(TicketDetail ticketDetail)
        {
            var oldTicketDetail = Items.FirstOrDefault(f => f.Id == ticketDetail.Id);
            if (oldTicketDetail == null)
            {
                Items.Add(ticketDetail);
            }
        }
    }
}
