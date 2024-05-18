using Crm.Domain.TicketDetailAgg.Repository;
using MediatR;

namespace Crm.Application.TicketDetail.UpdateStatusRead
{
    public class UpdateStatusReadTicketDetailCommandHandler : IRequestHandler<UpdateStatusReadTicketDetailCommand>
    {
        /// <summary>
        /// use TicketDetail repository
        /// </summary>
        private readonly ITicketDetailRepository _repository;

        public UpdateStatusReadTicketDetailCommandHandler(ITicketDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateStatusReadTicketDetailCommand request, CancellationToken cancellationToken)
        {
            var listTicketDetail = _repository.GetTickets();

            foreach (var ticketDetail in listTicketDetail)
            {
                if (ticketDetail.TicketId == request.TicketId)
                    if (ticketDetail.TicketReciver == request.TicketSender)
                        ticketDetail.ChangeStatusRead(Domain.TicketDetailAgg.Enums.StatusRead.Read);

                _repository.Update(ticketDetail);
            }
            await _repository.SaveChanges();
        }
    }
}
