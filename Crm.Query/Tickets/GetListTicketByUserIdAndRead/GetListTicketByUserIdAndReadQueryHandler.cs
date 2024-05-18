using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Query.Tickets.GetListTicketByUserIdAndRead
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListTicketByUserIdAndReadQueryHandler : IRequestHandler<GetListTicketByUserIdAndReadQuery, List<TicketDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListTicketByUserIdAndReadQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list Ticket with id user that get it
        /// </summary>
        /// <returns>list of ticketdto</returns>
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdAndReadQuery request, CancellationToken cancellationToken)
        {
            var userName = _context.Users.FirstOrDefault(r => r.Id == request.UserId);

            var tickets = _context.Tickets.FromSqlRaw
                (@$"Select * from Tickets where Id in 
                (Select TicketId from TicketDetails where 
                TicketReciver='{userName.UserName}' And ReadTicket=1)");
            
            var result = TicketMapper.TicketMapToListDto(tickets.ToList());

            return result;
        }
    }
}
