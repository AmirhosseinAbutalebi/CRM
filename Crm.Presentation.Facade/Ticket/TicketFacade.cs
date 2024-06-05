using Crm.Application.Ticket.Create;
using Crm.Query.Tickets.DTOs;
using Crm.Query.Tickets.GetDetailOfTicket;
using Crm.Query.Tickets.GetListTicketByUserId;
using Crm.Query.Tickets.GetListTicketByUserIdAndNotRead;
using Crm.Query.Tickets.GetListTicketByUserIdAndRead;
using Crm.Query.Tickets.GetListTicketByUserIdReciver;
using Crm.Query.Tickets.GetStatusTicketByUserId;
using Crm.Query.Tickets.GetStatusTicketByUserIdReciver;
using MediatR;
namespace Crm.Presentation.Facade.Ticket
{
    internal class TicketFacade : ITicketFacade
    {
        private readonly IMediator _mediator;

        public TicketFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task AddTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
        }
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId)
        {
            return await _mediator.Send(new GetListOfCurrentTicketByUserIdReciverQuery(userId));
        }
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId)
        {
            return await _mediator.Send(new GetListOfCurrentTicketByUserIdQuery(userId));
        }
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId)
        {
            return await _mediator.Send(new GetListOfFinishedTicketByUserIdReciverQuery(userId));
        }
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId)
        {
            return await _mediator.Send(new GetListOfFinishedTicketByUserIdQuery(userId));
        }
        public async Task<List<TicketDto>> GetTicketByUserId(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdQuery(userId));
        }
        public async Task<TicketDto> GetTicketDetailByUserId(long ticketId)
        {
            return await _mediator.Send(new GetDetailOfTicketQuery(ticketId));
        }
        public async Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdAndNotReadQuery(userId));
        }
        public async Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdAndReadQuery(userId));
        }
        public async Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver)
        {
            return await _mediator.Send(new GetListTicketByUserIdReciverQuery(userIdReciver));
        }
    }
}
