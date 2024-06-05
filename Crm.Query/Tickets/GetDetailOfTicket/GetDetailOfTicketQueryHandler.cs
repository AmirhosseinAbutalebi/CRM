using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Crm.Query.Tickets.GetDetailOfTicket
{
    public class GetDetailOfTicketQueryHandler : IRequestHandler<GetDetailOfTicketQuery, TicketDto>
    {
        private readonly CrmDbContext _context;
        public GetDetailOfTicketQueryHandler(CrmDbContext Context)
        {
            _context = Context;
        }
        public async Task<TicketDto> Handle(GetDetailOfTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(r => r.Id == request.TicketId);
            return TicketMapper.TicketMapToDto(ticket);
        }
    }
}
