using Crm.Application.Ticket.Create;
using Crm.Query.Tickets.DTOs;
using Crm.Query.Tickets.GetDetailOfTicket;
using Crm.Query.Tickets.GetListTicketByUserId;
using Crm.Query.Tickets.GetStatusTicketByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// constructor TicketController
        /// </summary>
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// controller for add ticket
        /// </summary>
        /// <param name="command">with type CreateTicketCommand</param>
        /// <returns>task</returns>
        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(CreateTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// get tickets by id
        /// </summary>
        /// <param name="userId">with type long </param>
        /// <returns>list of ticketdto</returns>
        [HttpGet("GetTicketsById")]
        public async Task<List<TicketDto>> GetTicketByUserId(long userId)
        {
            return await _mediator.Send(new GetListTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get ticket that during
        /// </summary>
        /// <param name="userId">with type userid</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetCurrentTicketsById")]
        public async Task<List<TicketDto>> GetCurrentTicketByUserId(long userId)
        {
            return await _mediator.Send(new GetListOfCurrentTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get tickets that finished
        /// </summary>
        /// <param name="userId">with type userid</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetFinishedTicketsById")]
        public async Task<List<TicketDto>> GetFinishedTicketByUserId(long userId)
        {
            return await _mediator.Send(new GetListOfFinishedTicketByUserIdQuery(userId));
        }
        /// <summary>
        /// get ticketdetail by id
        /// </summary>
        /// <param name="ticketId">with type long</param>
        /// <returns>ticket dto</returns>
        [HttpGet("GetTicketDetailById")]
        public async Task<TicketDto> GetTicketDetailByUserId(long ticketId)
        {
            return await _mediator.Send(new GetDetailOfTicketQuery(ticketId));
        }
    }
}
