
namespace Crm.Domain.TicketDetailAgg.Repository
{
    /// <summary>
    /// in this interface we define method needed in TicketDetailRepository
    /// then use in Application layer for commands
    /// </summary>
    public interface ITicketDetailRepository
    {
        /// <summary>
        /// method add for add TicketDetail to database
        /// </summary>
        /// <param name="ticketDetail">param ticketDetail with type TicketDetail</param>
        void Add(TicketDetail ticketDetail);
        /// <summary>
        /// method update for update TicketDetail in database 
        /// this project we dont need this method but 
        /// we define it
        /// </summary>
        /// <param name="ticketDetail">param ticketDetail with type TicketDetail</param>
        void Update(TicketDetail ticketDetail);
        /// <summary>
        /// method delete for delete ticketDetail with id from database
        /// and this method dont use in projcet too
        /// </summary>
        /// <param name="id">long id for get id ticketDetail that we wanna deleted</param>
        void Delete(long id);
        /// <summary>
        /// this method for save changes in database
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChanges();
        /// <summary>
        /// mehtod GetById for get TicketDetail with id from database
        /// </summary>
        /// <param name="id">long id for get TicketDetail that we wanna fetch and use in program</param>
        /// <returns>Task of TicketDetail</returns>
        Task<TicketDetail> GetById(long id);
        /// <summary>
        /// mehtod GetByTicketId for get TicketDetail with id Ticekt from database
        /// </summary>
        /// <param name="id">long id for get TicketDetail that we wanna fetch and use in program</param>
        /// <returns>List of TicketDetail</returns>
        List<TicketDetail> GetTickets();
    }
}
