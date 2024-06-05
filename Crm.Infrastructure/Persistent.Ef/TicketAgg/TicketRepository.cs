using Crm.Domain.TicketAgg;
using Crm.Domain.TicketAgg.Repository;
using Crm.Infrastructure.Persistent.Dapper;
using Crm.Infrastructure.Shared;
using Dapper;

namespace Crm.Infrastructure.Persistent.Ef.Ticket
{
    internal class TicketRepository : BaseRepository<Tickets>, ITicketRepository
    {
        private readonly DapperContext _dapperContext;
        public TicketRepository(CrmDbContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }


        public void Delete(long id)
        {
            _context.Remove(id);
        }

        public async Task<List<TicketDetail>> GetList()
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"select * from {_dapperContext.TicketDetail}";
            var result =  await connection.QueryAsync<TicketDetail>(sql);
            return result.ToList();
        }
    }
}
