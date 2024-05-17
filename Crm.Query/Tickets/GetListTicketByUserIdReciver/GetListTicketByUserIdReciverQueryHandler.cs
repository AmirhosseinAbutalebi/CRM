using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Query.Tickets.GetListTicketByUserIdReciver
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListTicketByUserIdReciverQueryHandler : IRequestHandler<GetListTicketByUserIdReciverQuery, List<TicketDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;

        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListTicketByUserIdReciverQueryHandler(CrmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// handle query and return list Ticket with id user reciver that get it
        /// </summary>
        /// <returns>list of ticketdto</returns>
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdReciverQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets
            .Where(r => r.UserIdReciver == request.UserIdReciver)
            .OrderByDescending(d => d.Id).ToListAsync();

            var result = TicketMapper.TicketMapToListDto(ticket);
            return result;
        }
    }
}
