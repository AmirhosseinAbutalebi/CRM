using Crm.Application.Ticket.Create;
using Crm.Query.Tickets.DTOs;
namespace Crm.Presentation.Facade.Ticket
{
    public interface ITicketFacade
    {
        Task AddTicket(CreateTicketCommand command);

        Task<List<TicketDto>> GetTicketByUserId(long userId);
        Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId);
        Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId);
        Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId);
        Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId);
        Task<TicketDto> GetTicketDetailByUserId(long ticketId);
        Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver);
        Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId);
        Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId);
    }
}
