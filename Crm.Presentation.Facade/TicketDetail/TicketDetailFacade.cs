using Crm.Application.Ticket.CreateTicketDetail;
using Crm.Application.Ticket.UpdateStatusRead;
using Crm.Query.TicketDetail.DTOs;
using Crm.Query.TicketDetail.GetTicketDetailValue;
using MediatR;
namespace Crm.Presentation.Facade.TicketDetail
{
    internal class TicketDetailFacade : ITicketDetailFacade
    {
        private readonly IMediator _mediator;
        public TicketDetailFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task AddTicketDetail(CreateTicketDetailCommand command)
        {
            await _mediator.Send(command);
        }
        public async Task<List<TicketDetailDto>> GetTicketDetail(long ticketId)
        {
            return await _mediator.Send(new GetListTicketDetailValueQuery(ticketId));
        }
        public async Task UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
