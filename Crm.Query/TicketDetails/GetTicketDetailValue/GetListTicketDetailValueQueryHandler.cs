using Crm.Infrastructure.Persistent.Dapper;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.TicketDetail.DTOs;
using Dapper;
using MediatR;
namespace Crm.Query.TicketDetail.GetTicketDetailValue
{
    public class GetListTicketDetailValueQueryHandler : IRequestHandler<GetListTicketDetailValueQuery, List<TicketDetailDto>>
    {
        private readonly CrmDbContext _context;
        private readonly DapperContext _dapperContext;
        public GetListTicketDetailValueQueryHandler(CrmDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async Task<List<TicketDetailDto>> Handle(GetListTicketDetailValueQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"select * from {_dapperContext.TicketDetail} where TicketsId = @id";
            var ticketDetail = await connection.QueryAsync<TicketDetailDto>(sql, new {id = request.TicketId});


            var sqlSender = @$"select FirstName + ' ' + LastName as Fullname from {_dapperContext.TicketDetail}
                    inner join {_dapperContext.User} on
                    {_dapperContext.TicketDetail}.TicketSenderId = {_dapperContext.User}.Id";

            var senderUsers = await connection.QueryAsync<string>(sqlSender);
            

            var sqlReciver = @$"select FirstName + ' ' + LastName as Fullname from {_dapperContext.TicketDetail}
                    inner join {_dapperContext.User} on
                    {_dapperContext.TicketDetail}.TicketReciverId = {_dapperContext.User}.Id";

            var reciverUsers = await connection.QueryAsync<string>(sqlReciver);


            var fullnameSender = senderUsers.ToList();
            var fullnameReciver =  reciverUsers.ToList();
            
            var counter = 0;
            foreach (var item in ticketDetail)
            {
                item.FullNameSender = fullnameSender[counter];
                item.FullNameReciver = fullnameReciver[counter];
                counter += 1;
            }
            return ticketDetail.ToList();

        }
    }
}
