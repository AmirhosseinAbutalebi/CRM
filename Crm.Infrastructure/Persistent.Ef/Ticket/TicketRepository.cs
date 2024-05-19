using Crm.Domain.TicketAgg;
using Crm.Domain.TicketAgg.Repository;
using Microsoft.EntityFrameworkCore;
namespace Crm.Infrastructure.Persistent.Ef.Ticket
{
    /// <summary>
    /// infrastucre Iticketrepository that define in domain
    /// </summary>
    public class TicketRepository : ITicketRepository
    {
        /// <summary>
        /// use database for actions need to use
        /// </summary>
        private readonly CrmDbContext _context;

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="context">type database</param>
        public TicketRepository(CrmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// for add to database
        /// </summary>
        /// <param name="tickets">type of tickets</param>
        public void Add(Tickets tickets)
        {
            _context.Add(tickets);
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
        /// get ticket by id
        /// </summary>
        /// <param name="id">id ticket and type long</param>
        /// <returns> task of tickets (one ticket by Id == id)</returns>
        public async Task<Tickets> GetById(long id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(u => u.Id == id);
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
        /// <param name="tickets">type tickets</param>
        public void Update(Tickets tickets)
        {
            _context.Update(tickets);
        }
    }
}
