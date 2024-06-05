using Crm.Domain.TicketAgg.Enums;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetStatusTicketByUserIdReciver
{
    public class GetListOfCurrentTicketByUserIdReciverQueryHandler : IRequestHandler<GetListOfCurrentTicketByUserIdReciverQuery, List<TicketDto>>
    {
        private readonly CrmDbContext _context;
        public GetListOfCurrentTicketByUserIdReciverQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketDto>> Handle(GetListOfCurrentTicketByUserIdReciverQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _context.Tickets
                .Where(r => r.UserIdReciver == request.UserId && 
                r.StatusTicket == StatusTicket.During)
                .OrderByDescending(r => r.Id).ToListAsync();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            var fullName = user.FirstName + " " + user.LastName;

            var result = TicketMapper.TicketMapToListDto(tickets);
            foreach (var item in result)
            {
                item.FullName = fullName;
            }
            return result;
        }
    }
}
