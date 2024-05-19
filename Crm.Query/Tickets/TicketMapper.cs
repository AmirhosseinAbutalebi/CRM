using Crm.Query.Tickets.DTOs;
namespace Crm.Query.Tickets
{
    /// <summary>
    /// just map from Tickets to ticketDto and you can use mapper or autofac for this 
    /// </summary>
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
                UsernameReciver = x.UsernameReciver,
                UserIdReciver = x.UserIdReciver,
                UsernameSender = x.UsernameSender,
                
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
                UsernameReciver = tickets.UsernameReciver,
                UserIdReciver = tickets.UserIdReciver,
                UsernameSender = tickets.UsernameSender,
            };
        }
    }
}
