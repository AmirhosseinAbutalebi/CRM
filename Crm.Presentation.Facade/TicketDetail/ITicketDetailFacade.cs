using Crm.Application.Ticket.CreateTicketDetail;
using Crm.Application.Ticket.UpdateStatusRead;
using Crm.Query.TicketDetail.DTOs;
namespace Crm.Presentation.Facade.TicketDetail
{
    public interface ITicketDetailFacade
    {
        Task AddTicketDetail(CreateTicketDetailCommand command);
        Task UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command);
        Task<List<TicketDetailDto>> GetTicketDetail(long ticketId);
    }
}
