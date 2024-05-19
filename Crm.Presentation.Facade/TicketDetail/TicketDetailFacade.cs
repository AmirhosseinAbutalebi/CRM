using Crm.Application.TicketDetail.Create;
using Crm.Application.TicketDetail.UpdateStatusRead;
using Crm.Query.TicketDetail.DTOs;
using Crm.Query.TicketDetail.GetTicketDetailValue;
using MediatR;
namespace Crm.Presentation.Facade.TicketDetail
{
    /// <summary>
    /// service for TicketDetailFacade and infrastructure it with interface 
    /// ITicketDetailFacade and for infrastructure need mediatr
    /// </summary>
    internal class TicketDetailFacade : ITicketDetailFacade
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// constructor TicketDetailFacade
        /// </summary>
        public TicketDetailFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// add ticketdetail and start conversation between student and teacher
        /// </summary>
        /// <param name="command">with type CreateTicketDetailCommand</param>
        /// <returns>task</returns>
        public async Task AddTicketDetail(CreateTicketDetailCommand command)
        {
            await _mediator.Send(command);
        }
        /// <summary>
        /// get list of ticketdetail with id ticket
        /// </summary>
        /// <param name="ticketId">with type long</param>
        /// <returns>list ticketdetaildto</returns>
        public async Task<List<TicketDetailDto>> GetTicketDetail(long ticketId)
        {
            return await _mediator.Send(new GetListTicketDetailValueQuery(ticketId));
        }
        /// <summary>
        /// for update status read message in ticketdetail and need command UpdateStatusReadTicketDetailCommand
        /// </summary>
        /// <param name="command">with type UpdateStatusReadTicketDetailCommand</param>
        /// <returns>task</returns>
        public async Task UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
