using Crm.Application.TicketDetail.Create;
using Crm.Application.TicketDetail.UpdateStatusRead;
using Crm.Presentation.Facade.TicketDetail;
using Crm.Query.TicketDetail.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDetailController : ControllerBase
    {
        /// <summary>
        /// use iticketdetailfacade till use designpattern facade this project
        /// </summary>
        private readonly ITicketDetailFacade _ticketDetailFacade;
        /// <summary>
        /// constructor TicketDetailController
        /// </summary>
        public TicketDetailController(ITicketDetailFacade ticketDetailFacade)
        {
            _ticketDetailFacade = ticketDetailFacade;
        }
        /// <summary>
        /// add ticketdetail
        /// </summary>
        /// <param name="command">with type CreateTicketDetailCommand</param>
        /// <returns>task</returns>
        [HttpPost("AddTicketDetail")]
        public async Task<IActionResult> AddTicketDetail(CreateTicketDetailCommand command)
        {
            await _ticketDetailFacade.AddTicketDetail(command);
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
            await _ticketDetailFacade.UpdateTicketDetailToRead(command);
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
            return await _ticketDetailFacade.GetTicketDetail(ticketId);
        }
    }
}
