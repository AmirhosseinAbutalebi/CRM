using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetStatusTicketByUserId
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="TicketId">long ticket id </param>
    public record GetListOfCurrentTicketByUserIdQuery(long UserId): IRequest<List<TicketDto>>;
}
