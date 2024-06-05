using Crm.Query.TicketDetail.DTOs;
using MediatR;
namespace Crm.Query.TicketDetail.GetTicketDetailValue
{
    public record GetListTicketDetailValueQuery(long TicketId) : IRequest<List<TicketDetailDto>>;
}
