using Crm.Query.Tickets.DTOs;
using MediatR;

namespace Crm.Query.Tickets.GetListTicketByUserId
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="UserId">long user id </param>
    public record GetListTicketByUserIdQuery(long UserId) : IRequest<List<TicketDto>>;
}
