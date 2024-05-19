using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetListTicketByUserIdAndNotRead
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="UserId">long user id </param>
    public record GetListTicketByUserIdAndNotReadQuery(long UserId) : IRequest<List<TicketDto>>;
}
