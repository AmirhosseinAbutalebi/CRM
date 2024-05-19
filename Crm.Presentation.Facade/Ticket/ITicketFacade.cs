using Crm.Application.Ticket.Create;
using Crm.Query.Tickets.DTOs;

namespace Crm.Presentation.Facade.Ticket
{
    /// <summary>
    /// define interface for ticket that use facade in project and all command 
    /// and query need till define and in ticketfacade impelement and use it
    /// </summary>
    public interface ITicketFacade
    {
        /// <summary>
        /// for add ticket and need get createticketcommand
        /// </summary>
        /// <param name="command">with type createticketcommand</param>
        /// <returns>task</returns>
        Task AddTicket(CreateTicketCommand command);


        /// <summary>
        /// get list ticket by user id
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetTicketByUserId(long userId);
        /// <summary>
        /// get list ticket by by user id sender that not finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId);
        /// <summary>
        /// get list ticket by user id sender and ticket finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId);
        /// <summary>
        /// get list ticket by user id reciver and ticket not finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId);
        /// <summary>
        /// get list ticket by user id reciver and ticket finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId);
        /// <summary>
        /// get ticketdetail by ticket id
        /// </summary>
        /// <param name="ticketId">with type long</param>
        /// <returns>ticket dto</returns>
        Task<TicketDto> GetTicketDetailByUserId(long ticketId);
        /// <summary>
        /// get list ticket by user id reciver
        /// </summary>
        /// <param name="userIdReciver">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver);
        /// <summary>
        /// get list ticket by user id and ticket read
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId);
        /// <summary>
        /// get list ticekt by user id and ticket dont read
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId);
    }
}
