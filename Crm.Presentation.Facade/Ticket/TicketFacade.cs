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
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor TicketFacade
        /// </summary>
        public TicketFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add ticket to database
        /// </summary>
        /// <param name="command">with type createticketcommand</param>
        /// <returns>task</returns>
        public async Task AddTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
        }

        /// <summary>
        /// get ticket by user id reciver that ticket is during and not finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list of ticketdto </returns>
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId)
        {
            return await _mediator.Send(new GetListOfCurrentTicketByUserIdReciverQuery(userId));
        }
        /// <summary>
        /// get list of ticket by user id sender that not finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticekt dto</returns>
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId)
        {
            return await _mediator.Send(new GetListOfCurrentTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get list of ticket from user id reciver that finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId)
        {
            return await _mediator.Send(new GetListOfFinishedTicketByUserIdReciverQuery(userId));
        }
        /// <summary>
        /// get list of ticket by user id sender that finished
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId)
        {
            return await _mediator.Send(new GetListOfFinishedTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get ticket by user id sender
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetTicketByUserId(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get ticket detail by user id sender
        /// </summary>
        /// <param name="ticketId">with type ticketid</param>
        /// <returns>ticket dto</returns>
        public async Task<TicketDto> GetTicketDetailByUserId(long ticketId)
        {
            return await _mediator.Send(new GetDetailOfTicketQuery(ticketId));
        }
        /// <summary>
        /// get ticket by user id and this ticket dont read
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdAndNotReadQuery(userId));
        }
        /// <summary>
        /// get ticket by user id and this ticket read with user
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdAndReadQuery(userId));
        }
        /// <summary>
        /// get tickets by user id reciver
        /// </summary>
        /// <param name="userIdReciver">with type long</param>
        /// <returns>list ticket dto</returns>
        public async Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver)
        {
            return await _mediator.Send(new GetListTicketByUserIdReciverQuery(userIdReciver));
        }
    }
}
