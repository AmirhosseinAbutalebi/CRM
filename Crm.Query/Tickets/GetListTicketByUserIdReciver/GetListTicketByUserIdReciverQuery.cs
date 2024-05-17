using Crm.Query.Tickets.DTOs;
using MediatR;

namespace Crm.Query.Tickets.GetListTicketByUserIdReciver
{
    // <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="UserIdReciver">long user reciver id </param>
    public record GetListTicketByUserIdReciverQuery(long UserIdReciver) : IRequest<List<TicketDto>>;
}
