using Crm.Domain.TicketAgg.Enums;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetStatusTicketByUserId
{
    public class GetListOfCurrentTicketByUserIdQueryHandler : IRequestHandler<GetListOfCurrentTicketByUserIdQuery, List<TicketDto>>
    {
        private readonly CrmDbContext _context;
        public GetListOfCurrentTicketByUserIdQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketDto>> Handle(GetListOfCurrentTicketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets
            .Where(r => r.UserIdSender == request.UserId && r.StatusTicket == StatusTicket.During)
            .OrderByDescending(d => d.Id).ToListAsync();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            var fullName = user.FirstName + " " + user.LastName;

            var result = TicketMapper.TicketMapToListDto(ticket);
            foreach (var item in result)
            {
                item.FullName = fullName;
            }
            return result;
        }
    }
}
