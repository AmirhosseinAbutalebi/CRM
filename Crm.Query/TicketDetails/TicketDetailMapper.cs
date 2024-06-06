using Crm.Query.TicketDetail.DTOs;
namespace Crm.Query.TicketDetail
{
    public class TicketDetailMapper
    {
        public static TicketDetailDto TicketDetailMapToDto(Domain.TicketAgg.TicketDetail  ticket)
        {
            if (ticket == null)
                return null;

            return new TicketDetailDto()
            {
                Id = ticket.Id,
                TicketsId = ticket.TicketsId,
                Text = ticket.Text,
                StatusTicket = ticket.StatusTicket,
                ReadTicket = ticket.ReadTicket,
                TicketReciverId = ticket.TicketReciverId,
                TicketSenderId = ticket.TicketSenderId,
            };
        }

        public static List<TicketDetailDto> TicketDetailMapToListDto(List<Domain.TicketAgg.TicketDetail> tickets)
        {
            if (tickets == null)
                return null;

            var listTicket = tickets.Select(x => new TicketDetailDto()
            {
                Id = x.Id,
                TicketsId = x.TicketsId,
                Text = x.Text,
                StatusTicket = x.StatusTicket,
                ReadTicket = x.ReadTicket,
                TicketReciverId = x.TicketReciverId,
                TicketSenderId = x.TicketSenderId,

            }).ToList();

            return listTicket;
        }
    }
}
