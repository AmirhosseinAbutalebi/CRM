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
        /// <summary>
        /// add ticketfacde till use pattern design
        /// </summary>
        private readonly ITicketFacade _ticketFacade;
        /// <summary>
        /// constructor ticketcontroller
        /// </summary>
        /// <param name="ticketFacade"> with type Iticketfacade</param>
        public TicketController(ITicketFacade ticketFacade)
        {
            _ticketFacade = ticketFacade;
        }

        /// <summary>
        /// controller for add ticket
        /// </summary>
        /// <param name="command">with type CreateTicketCommand</param>
        /// <returns>task</returns>
        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(CreateTicketCommand command)
        {
            await _ticketFacade.AddTicket(command);
            return Ok();
        }
        /// <summary>
        /// get tickets by id
        /// </summary>
        /// <param name="userId">with type long </param>
        /// <returns>list of ticketdto</returns>
        [HttpGet("GetTicketsByIdSender")]
        public async Task<List<TicketDto>> GetTicketByUserId(long userId)
        {
            return await _ticketFacade.GetTicketByUserId(userId);
        }
        /// <summary>
        /// get ticket that during
        /// </summary>
        /// <param name="userId">with type userid</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetCurrentTicketsByIdSender")]
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdSender(long userId)
        {
            return await _ticketFacade.GetCurrentTicketByUserIdSender(userId);
        }
        /// <summary>
        /// get tickets that finished
        /// </summary>
        /// <param name="userId">with type userid</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetFinishedTicketsByIdSender")]
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdSender(long userId)
        {
            return await _ticketFacade.GetFinishedTicketByUserIdSender(userId);
        }

        /// <summary>
        /// get tickets not finished with user id reciver
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetCurrentTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetCurrentTicketByUserIdReciver(long userId)
        {
            return await _ticketFacade.GetCurrentTicketByUserIdReciver(userId);
        }
        /// <summary>
        /// get tickets that finished
        /// </summary>
        /// <param name="userId">with type userid</param>
        /// <returns>list ticket dto</returns>
        [HttpGet("GetFinishedTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetFinishedTicketByUserIdReciver(long userId)
        {
            return await _ticketFacade.GetFinishedTicketByUserIdReciver(userId);
        }
        /// <summary>
        /// get ticketdetail by id
        /// </summary>
        /// <param name="ticketId">with type long</param>
        /// <returns>ticket dto</returns>
        [HttpGet("GetTicketDetailById")]
        public async Task<TicketDto> GetTicketDetailByUserId(long ticketId)
        {
            return await _ticketFacade.GetTicketDetailByUserId(ticketId);
        }
        /// <summary>
        /// get tickets by id user reciver
        /// </summary>
        /// <param name="userIdReciver">with type long</param>
        /// <returns>ticket dto</returns>
        [HttpGet("GetTicketsByIdReciver")]
        public async Task<List<TicketDto>> GetTicketsByUserIdReciver(long userIdReciver)
        {
            return await _ticketFacade.GetTicketsByUserIdReciver(userIdReciver);
        }

        /// <summary>
        /// get tickets by id user and ticketdetail with status Read
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>ticket dto</returns>
        [HttpGet("GetTicketsByIdAndRead")]
        public async Task<List<TicketDto>> GetTicketsByUserIdAndRead(long userId)
        {
            return await _ticketFacade.GetTicketsByUserIdAndRead(userId);
        }

        /// <summary>
        /// get tickets by id user and ticketdetail with status dont read
        /// </summary>
        /// <param name="userId">with type long</param>
        /// <returns>ticket dto</returns>
        [HttpGet("GetTicketsByIdAndDontRead")]
        public async Task<List<TicketDto>> GetTicketsByUserIdAndDontRead(long userId)
        {
            return await _ticketFacade.GetTicketsByUserIdAndDontRead(userId);
        }
    }
}
