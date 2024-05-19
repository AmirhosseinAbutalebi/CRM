using Crm.Application.TicketDetail.Create;
using Crm.Application.TicketDetail.UpdateStatusRead;
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
