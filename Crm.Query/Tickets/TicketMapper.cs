using Crm.Query.Tickets.DTOs;
namespace Crm.Query.Tickets
{
    public class TicketMapper
    {
        public static List<TicketDto> TicketMapToListDto(List<Domain.TicketAgg.Tickets> tickets)
        {
            if (tickets == null)
                return null;

            var listTicket = tickets.Select(x => new TicketDto()
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                UserIdSender = x.UserIdSender,
                UserIdReciver = x.UserIdReciver,
                statusticket = x.StatusTicket
                
            }).ToList();

            return listTicket;
        }

        public static TicketDto TicketMapToDto(Domain.TicketAgg.Tickets tickets)
        {
            if (tickets == null)
                return null;

            return new TicketDto()
            {
                Id = tickets.Id,
                Description = tickets.Description,
                Title = tickets.Title,
                UserIdSender = tickets.UserIdSender,
                UserIdReciver = tickets.UserIdReciver,
                statusticket = tickets.StatusTicket
            };
        }
    }
}
