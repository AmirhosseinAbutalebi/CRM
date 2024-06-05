using Crm.Domain.TicketAgg;
using Crm.Domain.TicketAgg.Enums;
using Crm.Domain.TicketAgg.Repository;
using MediatR;

namespace Crm.Application.Ticket.CreateTicketDetail
{
    public class CreateTicketDetailCommandHandler : IRequestHandler<CreateTicketDetailCommand>
    {
        private readonly ITicketRepository _repository;
        
        public CreateTicketDetailCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(CreateTicketDetailCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetAsync(request.TicketId);
            var ticketDetail = new TicketDetail(request.Text, request.TicketSenderId,
                request.TicketReciverId, request.ReadTicket, request.StatusTicket, request.TicketId);

            var tickets = new Tickets(ticket.UserIdSender, ticket.UserIdReciver, ticket.Title, ticket.Description);

            ticket.AddticketDetail(ticketDetail);
            _repository.Update(ticket);

            if (ticketDetail.StatusTicket == StatusTicket.Finished)
            {
                var ticketUpdated = await _repository.GetAsync(ticketDetail.TicketsId);
                if (ticketUpdated != null) 
                    ticketUpdated.ChangeStatusTicket(ticketDetail.StatusTicket);
            }
            await _repository.Save();
        }
    }
}
