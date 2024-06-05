using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetListTicketByUserIdReciver
{
    public class GetListTicketByUserIdReciverQueryHandler : IRequestHandler<GetListTicketByUserIdReciverQuery, List<TicketDto>>
    {
        private readonly CrmDbContext _context;

        public GetListTicketByUserIdReciverQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdReciverQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets
            .Where(r => r.UserIdReciver == request.UserIdReciver)
            .OrderByDescending(d => d.Id).ToListAsync();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserIdReciver);
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
