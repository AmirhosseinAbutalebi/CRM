using Crm.Query.Tickets.DTOs;
using MediatR;
namespace Crm.Query.Tickets.GetStatusTicketByUserIdReciver
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="UserId">long User id </param>
    public record GetListOfFinishedTicketByUserIdReciverQuery(long UserId) : IRequest<List<TicketDto>>;
}
