﻿
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Query.Tickets.GetStatusTicketByUserId
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListOfCurrentTicketByUserIdQueryHandler : IRequestHandler<GetListOfCurrentTicketByUserIdQuery, List<TicketDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListOfCurrentTicketByUserIdQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list Ticket that during with id user that get it
        /// </summary>
        /// <returns>list of ticketdto</returns>
        public async Task<List<TicketDto>> Handle(GetListOfCurrentTicketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets
            .Where(r => r.UserIdSender == request.UserId && r.StatusTicket == Domain.TicketDetailAgg.Enums.StatusTicket.During)
            .OrderByDescending(d => d.Id).ToListAsync();

            var result = TicketMapper.TicketMapToListDto(ticket);
            return result;
        }
    }
}