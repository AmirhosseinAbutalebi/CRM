using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetListTicketByUserIdAndNotRead
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListTicketByUserIdAndNotReadQueryHandler : IRequestHandler<GetListTicketByUserIdAndNotReadQuery, List<TicketDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListTicketByUserIdAndNotReadQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list Ticket with id user that get it
        /// </summary>
        /// <returns>list of ticketdto</returns>
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdAndNotReadQuery request, CancellationToken cancellationToken)
        {
            var userName = _context.Users.FirstOrDefault(r => r.Id == request.UserId);

            var tickets = _context.Tickets.FromSqlRaw
                (@$"Select * from Tickets where Id in 
                (Select TicketId from TicketDetails where 
                TicketReciver='{userName.UserName}' And ReadTicket=0)");

            var fullName = userName.FirstName + " " + userName.LastName;

            var result = TicketMapper.TicketMapToListDto(tickets.ToList());
            foreach (var item in result)
            {
                item.FullName = fullName;
            }
            return result;
        }
    }
}
