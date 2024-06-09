using Crm.Application.Ticket.CreateTicketDetail;
using Crm.Application.Ticket.UpdateStatusRead;
using Crm.Presentation.Facade.TicketDetail;
using Crm.Query.TicketDetail.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDetailController : ControllerBase
    {
        private readonly ITicketDetailFacade _ticketDetailFacade;
        public TicketDetailController(ITicketDetailFacade ticketDetailFacade)
        {
            _ticketDetailFacade = ticketDetailFacade;
        }
        [HttpPost("AddTicketDetail")]
        public async Task<IActionResult> AddTicketDetail(CreateTicketDetailCommand command)
        {
            await _ticketDetailFacade.AddTicketDetail(command);
            return Ok("تیکت جدید ثبت شد");
        }
        [HttpPut("UpdateTicketDetailToRead")]
        public async Task<IActionResult> UpdateTicketDetailToRead(UpdateStatusReadTicketDetailCommand command)
        {
            await _ticketDetailFacade.UpdateTicketDetailToRead(command);
            return Ok();
        }
        [HttpGet("GetListTicketDetail/{ticketId}")]
        public async Task<List<TicketDetailDto>> GetTicketDetail(long ticketId)
        {
            return await _ticketDetailFacade.GetTicketDetail(ticketId);
        }
    }
}
