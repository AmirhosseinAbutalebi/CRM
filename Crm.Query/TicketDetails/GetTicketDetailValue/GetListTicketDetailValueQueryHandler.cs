using Crm.Domain.TicketAgg;
using Crm.Infrastructure.Persistent.Dapper;
using Crm.Infrastructure.Persistent.Ef;
using Crm.Query.TicketDetail.DTOs;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
           
            var sender = new List<long>();
            var reciver = new List<long>();

            foreach (var item in ticketDetail)
            {
                sender.Add(item.TicketSenderId);
                reciver.Add(item.TicketReciverId);
            }



            var fullnameSender = new List<string>();
            var fullnameReciver = new List<string>();

            var resu = _context.Users.ToList();

            foreach (var item in resu)
            {
                foreach (var user in sender)
                {
                    if(item.Id == user)
                    {
                        fullnameSender.Add(item.FirstName+" "+item.LastName);
                    }
                }
                foreach (var user in reciver)
                {
                    if (item.Id == user)
                    {
                        fullnameReciver.Add(item.FirstName + " " + item.LastName);
                    }
                }
            }

            fullnameSender.Reverse();

            var counter = 0;
            foreach(var item in ticketDetail)
            {
                item.FullNameSender = fullnameSender[counter];
                item.FullNameReciver = fullnameReciver[counter];
                counter += 1;
            }
            return ticketDetail.ToList();

        }
    }
}
