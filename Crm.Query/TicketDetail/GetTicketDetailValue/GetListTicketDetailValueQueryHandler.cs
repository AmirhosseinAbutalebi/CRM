using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.TicketDetail.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.TicketDetail.GetTicketDetailValue
{
    /// <summary>
    /// infrastructure query and we need irequesthandler with querydto and base dto
    /// </summary>
    public class GetListTicketDetailValueQueryHandler : IRequestHandler<GetListTicketDetailValueQuery, List<TicketDetailDto>>
    {
        /// <summary>
        /// use database for use it in handler
        /// </summary>
        private readonly CrmDbContext _context;
        /// <summary>
        /// constructor of class
        /// </summary>
        /// <param name="context">context with type crmdbconntext</param>
        public GetListTicketDetailValueQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// handle query and return list ticketdetail with id ticket that get it
        /// </summary>
        /// <returns>list of ticketdetail</returns>
        public async Task<List<TicketDetailDto>> Handle(GetListTicketDetailValueQuery request,
            CancellationToken cancellationToken)
        {
            var ticketDetail = await _context.TicketDetails
            .Where(r => r.TicketId == request.TicketId)
            .OrderByDescending(d => d.Id).ToListAsync();

            var userSender = _context.Users.Where(r => r.UserName == ticketDetail.Select(p=> p.TicketSender)
            .FirstOrDefault()).Single();
            var userReciver = _context.Users.Where(r => r.UserName == ticketDetail.Select(p => p.TicketReciver)
            .FirstOrDefault()).Single();

            var fullnameSender = userSender.FirstName + " " + userSender.LastName;
            var fullnameReciver = userReciver.FirstName + " " + userReciver.LastName;

            var result = TicketDetailMapper.TicketDetailMapToListDto(ticketDetail);

            foreach(var item in result)
            {
                item.FullNameSender = fullnameSender;
                item.FullNameReciver = fullnameReciver;
            }
            return result;

        }
    }
}
