using Crm.Application.TicketDetail.Create;
using Crm.Application.TicketDetail.UpdateStatusRead;
using Crm.Query.TicketDetail.DTOs;
namespace Crm.Presentation.Facade.TicketDetail
{
    /// <summary>
    /// define interface for ticketdetail that use facade in project and all command 
    /// and query need till define and in ticketdetailfacade impelement and use it
    /// </summary>
    public interface ITicketDetailFacade
    {
        /// <summary>
        /// for add ticketDetail in database and need command from CreateTicketDetailCommand
        /// </summary>
        /// <param name="command">with type CreateTicketDetailCommand</param>
        /// <returns>task</returns>
        Task AddTicketDetail(CreateTicketDetailCommand command);
        /// <summary>
        /// for update status Read in ticketDetail and need command from 
        /// UpdateStatusReadTicektDetailCommand
        /// </summary>
        /// <param name="command">with type UpdateStatusReadTicketDetailCommand</param>
        /// <returns>task</returns>
        Task UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command);

        /// <summary>
        /// get list of ticketDetail and need ticketid for get list 
        /// </summary>
        /// <param name="ticketId">with type long</param>
        /// <returns>list ticketDetailDto</returns>
        Task<List<TicketDetailDto>> GetTicketDetail(long ticketId);
    }
}
