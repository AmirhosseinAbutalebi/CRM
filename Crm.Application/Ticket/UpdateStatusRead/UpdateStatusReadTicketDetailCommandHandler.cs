using Crm.Domain.TicketAgg.Enums;
using Crm.Domain.TicketAgg.Repository;
using MediatR;

namespace Crm.Application.Ticket.UpdateStatusRead
{
    public class UpdateStatusReadTicketDetailCommandHandler : IRequestHandler<UpdateStatusReadTicketDetailCommand>
    {
        private readonly ITicketRepository _repository;

        public UpdateStatusReadTicketDetailCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateStatusReadTicketDetailCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetAsync(request.TicketId);

            if (ticket == null)
                throw new InvalidDataException("چنین تیکتی وجو ندارد");
            var listTicketDetail = ticket.Items;

            foreach (var ticketDetail in listTicketDetail)
            {
                if (ticketDetail.TicketsId == request.TicketId)
                    if (ticketDetail.TicketReciverId == request.TicketReciverId)
                        ticketDetail.ChangeStatusRead(StatusRead.Read);
            }
            _repository.Update(ticket);
            await _repository.Save();
        }
    }
}
