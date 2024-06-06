using Crm.Application.Ticket.Create;
using Crm.Presentation.Facade.Ticket;
using Crm.Query.Tickets.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketFacade _ticketFacade;
        public TicketController(ITicketFacade ticketFacade)
        {
            _ticketFacade = ticketFacade;
        }

        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(CreateTicketCommand command)
        {
            await _ticketFacade.AddTicket(command);
            return Ok("تیکت با موفقیت ایجاد شد");
        }
        [HttpGet("GetTicketsByIdSender")]
        public async Task<List<TicketDto>> GetTicketByUserId(long userId)
        {
            return await _ticketFacade.GetTicketByUserId(userId);
        }
        [HttpGet("GetCurrentTicketsByIdSender")]
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId)
        {
            return await _ticketFacade.GetCurrentTicketByUserIdSender(userId);
        }
        [HttpGet("GetFinishedTicketsByIdSender")]
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId)
        {
            return await _ticketFacade.GetFinishedTicketByUserIdSender(userId);
        }

        [HttpGet("GetCurrentTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId)
        {
            return await _ticketFacade.GetCurrentTicketByUserIdReciver(userId);
        }
        [HttpGet("GetFinishedTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId)
        {
            return await _ticketFacade.GetFinishedTicketByUserIdReciver(userId);
        }
        [HttpGet("GetTicketDetailById")]
        public async Task<TicketDto> GetTicketDetailByUserId(long ticketId)
        {
            return await _ticketFacade.GetTicketDetailByUserId(ticketId);
        }
        [HttpGet("GetTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver)
        {
            return await _ticketFacade.GetTicketsByUserIdReciver(userIdReciver);
        }

        [HttpGet("GetTicketsByIdAndRead")]
        public async Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId)
        {
            return await _ticketFacade.GetTicketsByUserIdAndRead(userId);
        }

        [HttpGet("GetTicketsByIdAndDontRead")]
        public async Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId)
        {
            return await _ticketFacade.GetTicketsByUserIdAndDontRead(userId);
        }
    }
}
