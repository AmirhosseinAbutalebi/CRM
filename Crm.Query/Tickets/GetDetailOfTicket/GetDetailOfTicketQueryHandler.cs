using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetDetailOfTicket
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetDetailOfTicketQueryHandler : IRequestHandler<GetDetailOfTicketQuery, TicketDto>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="Context">context with type crmdbconntext</param>
        public GetDetailOfTicketQueryHandler(CrmDbContext Context)
        {
            _context = Context;
        }
        /// <summary>
        /// handle query and return Ticket with id ticket that get it
        /// </summary>
        /// <returns>ticketdto</returns>
        public async Task<TicketDto> Handle(GetDetailOfTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(r => r.Id == request.TicketId);
            return TicketMapper.TicketMapToDto(ticket);
        }
    }
}
