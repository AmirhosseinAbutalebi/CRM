using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Query.Tickets.GetStatusTicketByUserIdReciver
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListOfFinishedTicketByUserIdReciverQueryHandler : IRequestHandler<GetListOfFinishedTicketByUserIdReciverQuery, List<TicketDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListOfFinishedTicketByUserIdReciverQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list Ticket that finished with id user reciver that get it
        /// </summary>
        /// <returns>list of ticketdto</returns>
        public async Task<List<TicketDto>> Handle(GetListOfFinishedTicketByUserIdReciverQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _context.Tickets.Where(r=>r.UserIdReciver == request.UserId &&
                r.StatusTicket == Domain.TicketDetailAgg.Enums.StatusTicket.Finished)
                .OrderByDescending(r => r.Id).ToListAsync();

            return TicketMapper.TicketMapToListDto(tickets);
        }
    }
}
