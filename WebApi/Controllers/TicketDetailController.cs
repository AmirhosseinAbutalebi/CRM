using Crm.Application.TicketDetail.Create;
using Crm.Application.TicketDetail.UpdateStatusRead;
using Crm.Query.TicketDetail.DTOs;
using Crm.Query.TicketDetail.GetTicketDetailValue;
using Crm.Query.Users.GetTeacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDetailController : ControllerBase
    {
        /// <summary>
        /// use IMediator in project and just define IMediator and use with send command
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// constructor TicketController
        /// </summary>
        public TicketDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// add ticketdetail
        /// </summary>
        /// <param name="command">with type CreateTicketDetailCommand</param>
        /// <returns>task</returns>
        [HttpPost("AddTicketDetail")]
        public async Task<IActionResult> AddTicketDetail(CreateTicketDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// update ticketdetail and change statusread from 0 to 1
        /// </summary>
        /// <param name="command">with type UpdateStatusReadTicketDetailCommand</param>
        /// <returns>task</returns>
        [HttpPut("UpdateTicketDetailToRead")]
        public async Task<IActionResult> UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        /// <summary>
        /// get list ticketdetail with id ticket
        /// </summary>
        /// <param name="ticketId">with type id</param>
        /// <returns>return list of ticketdetaildto</returns>
        [HttpGet("GetListTicketDetail")]
        public async Task<List<TicketDetailDto>> GetTicketDetail(long ticketId)
        {
            return await _mediator.Send(new GetListTicketDetailValueQuery(ticketId));
        }
    }
}
