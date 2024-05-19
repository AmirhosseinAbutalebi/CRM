namespace Crm.Domain.TicketAgg.Repository
{
    /// <summary>
    /// in this interface we define method needed in TicketRepsiotry
    /// then use in Application layer for commands
    /// </summary>
    public interface ITicketRepository
    {
        /// <summary>
        /// method add for add tickets to database
        /// </summary>
        /// <param name="tickets">param tickets with type Tickets</param>
        void Add(Tickets tickets);

        /// <summary>
        /// method update for update ticket in database 
        /// this project we dont need this method but 
        /// we define it
        /// </summary>
        /// <param name="tickets">param tickets with type Tickets</param>
        void Update(Tickets tickets);

        /// <summary>
        /// method delete for delete ticket with id from database
        /// and this method dont use in projcet too
        /// </summary>
        /// <param name="id">long id for get id ticket that we wanna deleted</param>
        void Delete(long id);

        /// <summary>
        /// this method for save changes in database
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChanges();

        /// <summary>
        /// mehtod GetById for get ticket with id from database
        /// </summary>
        /// <param name="id">long id for get ticket that we wanna fetch and use in program</param>
        /// <returns>Task of Tickets</returns>
        Task<Tickets> GetById(long id);
    }
}
