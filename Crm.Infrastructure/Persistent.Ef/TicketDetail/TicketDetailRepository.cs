using Crm.Domain.TicketDetailAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Persistent.Ef.TicketDetail
{
    /// <summary>
    /// infrastucre ITicketDetailRepository that define in domain
    /// </summary>
    public class TicketDetailRepository : ITicketDetailRepository
    {
        /// <summary>
        /// use database for actions need to use
        /// </summary>
        private readonly CrmDbContext _context;

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="context">type database</param>
        public TicketDetailRepository(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// for add to database
        /// </summary>
        /// <param name="ticketDetail">type of ticketDetail</param>
        public void Add(Domain.TicketDetailAgg.TicketDetail ticketDetail)
        {
            _context.Add(ticketDetail);
        }
        /// <summary>
        /// for delete by id
        /// </summary>
        /// <param name="id">id ticket and type long</param>
        public void Delete(long id)
        {
            _context.Remove(id);
        }
        /// <summary>
        /// for save data in database
        /// </summary>
        /// <returns>task</returns>
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// for update database
        /// </summary>
        /// <param name="ticketDetail">type TicketDetail</param>
        public void Update(Domain.TicketDetailAgg.TicketDetail ticketDetail)
        {
            _context.Update(ticketDetail);
        }
        /// <summary>
        /// get ticketdetail by id
        /// </summary>
        /// <param name="id">id ticketdetail and type long</param>
        /// <returns> task of TicketDetail (one TicketDetail by Id == id)</returns>
        public async Task<Domain.TicketDetailAgg.TicketDetail> GetById(long id)
        {
            return await _context.TicketDetails.FirstOrDefaultAsync(u => u.Id == id);
        }

        public List<Domain.TicketDetailAgg.TicketDetail> GetTickets()
        {
            return _context.TicketDetails.ToList();
        }
    }
}
