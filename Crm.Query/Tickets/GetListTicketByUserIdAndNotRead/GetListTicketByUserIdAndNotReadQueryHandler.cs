using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetListTicketByUserIdAndNotRead
{
    public class GetListTicketByUserIdAndNotReadQueryHandler : IRequestHandler<GetListTicketByUserIdAndNotReadQuery, List<TicketDto>>
    {
        private readonly CrmDbContext _context;
        public GetListTicketByUserIdAndNotReadQueryHandler(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdAndNotReadQuery request, CancellationToken cancellationToken)
        {
            var userName = _context.Users.FirstOrDefault(r => r.Id == request.UserId);

            var tickets = _context.Tickets.FromSqlRaw
                (@$"Select * from [ticket].[Tickets] where Id in 
                (Select TicketsId from [ticket].[TicketDetails] where 
                TicketReciverId='{userName.Id}' And ReadTicket=0)");

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
