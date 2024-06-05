using Crm.Domain.Shared;

namespace Crm.Domain.TicketAgg.Repository
{
    public interface ITicketRepository : IBaseRepositroy<Tickets>
    {
        void Delete(long id);
    }
}
