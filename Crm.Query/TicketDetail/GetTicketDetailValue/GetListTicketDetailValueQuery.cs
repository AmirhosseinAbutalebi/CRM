using Crm.Query.TicketDetail.DTOs;
using MediatR;
namespace Crm.Query.TicketDetail.GetTicketDetailValue
{
    /// <summary>
    /// define recorde that use in mediatr and that diffrence between this and command is 
    /// irequest there need dto and in command dont need
    /// </summary>
    /// <param name="TicketId">long ticket id </param>
    public record GetListTicketDetailValueQuery(long TicketId) : IRequest<List<TicketDetailDto>>;
}
