using Crm.Query.TicketDetail.DTOs;

namespace Crm.Query.TicketDetail
{
    /// <summary>
    /// just map from ticketdetail to ticketdetaildto and you can use mapper or autofac for this 
    /// </summary>
    public class TicketDetailMapper
    {
        public static TicketDetailDto TicketDetailMapToDto(Domain.TicketDetailAgg.TicketDetail  tickets)
        {
            if (tickets == null)
                return null;

            return new TicketDetailDto()
            {
                Id = tickets.Id,
                TicketId = tickets.TicketId,
                Text = tickets.Text,
                StatusTicket = tickets.StatusTicket,
                ReadTicket = tickets.ReadTicket,
                TicketReciver = tickets.TicketReciver,
                TicketSender = tickets.TicketSender,
            };
        }

        public static List<TicketDetailDto> TicketDetailMapToListDto(List<Domain.TicketDetailAgg.TicketDetail> tickets)
        {
            if (tickets == null)
                return null;

            var listTicket = tickets.Select(x => new TicketDetailDto()
            {
                Id = x.Id,
                TicketId = x.TicketId,
                Text = x.Text,
                StatusTicket = x.StatusTicket,
                ReadTicket = x.ReadTicket,
                TicketReciver = x.TicketReciver,
                TicketSender = x.TicketSender,

            }).ToList();

            return listTicket;
        }
    }
}
