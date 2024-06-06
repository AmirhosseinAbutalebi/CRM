using Crm.Infrastructure.Persistent.Dapper;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.Tickets.DTOs;
using Dapper;
using MediatR;
namespace Crm.Query.Tickets.GetListTicketByUserIdAndNotRead
{
    public class GetListTicketByUserIdAndNotReadQueryHandler : IRequestHandler<GetListTicketByUserIdAndNotReadQuery, List<TicketDto>>
    {
        private readonly CrmDbContext _context;
        private readonly DapperContext _dapperContext;
        public GetListTicketByUserIdAndNotReadQueryHandler(CrmDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async Task<List<TicketDto>> Handle(GetListTicketByUserIdAndNotReadQuery request, CancellationToken cancellationToken)
        {
            var userName = _context.Users.FirstOrDefault(r => r.Id == request.UserId);

            using var connection = _dapperContext.CreateConnection();
            var sql = @$"Select * from {_dapperContext.Ticket} where Id in 
                (Select TicketsId from {_dapperContext.TicketDetail} where 
                TicketReciverId=@id And ReadTicket=0)";
            var tickets = await connection.QueryAsync<TicketDto>(sql, new { id = userName.Id });
            var result = tickets.ToList();

            var fullName = userName.FirstName + " " + userName.LastName;

            foreach (var item in result)
            {
                item.FullName = fullName;
            }
            return result;
        }
    }
}
