﻿using Crm.Domain.TicketAgg.Repository;
using Crm.Domain.TicketDetailAgg.Enums;
using Crm.Domain.TicketDetailAgg.Repository;
using MediatR;

namespace Crm.Application.TicketDetail.Create
{
    /// <summary>
    /// this class handle CreateTicketDetailCommand and need to inhert IRequstHandler<> with dto that define for it
    /// and then handle instructure command in method Handle and need to define as internal class
    /// </summary>
    public class CreateTicketDetailCommandHandler : IRequestHandler<CreateTicketDetailCommand>
    {
        /// <summary>
        /// use TicketDetail repository
        /// </summary>
        private readonly ITicketDetailRepository _repository;
        /// <summary>
        /// use Ticket repository
        /// </summary>
        private readonly ITicketRepository _ticketrepository;
        /// <summary>
        /// constructor of CreateTicketDetailCommandHandler
        /// </summary>
        /// <param name="repository">set ticketdetail repository</param>
        public CreateTicketDetailCommandHandler(ITicketDetailRepository repository, ITicketRepository ticketRepository)
        {
            _repository = repository;
            _ticketrepository = ticketRepository;
        }
        /// <summary>
        /// infrastructure of command in this method 
        /// </summary>
        /// <param name="request">data needed and get in CreateTicketdetailCommand</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>task and save data in database</returns>
        public async Task Handle(CreateTicketDetailCommand request, CancellationToken cancellationToken)
        {
            ///add ticketdetail in database
            var ticketDetail = new Domain.TicketDetailAgg.TicketDetail(request.Text, request.TicketSender,
                request.TicketReciver, request.ReadTicket, request.StatusTicket, request.TicketId);
            _repository.Add(ticketDetail);
            await _repository.SaveChanges();

            if(ticketDetail.StatusTicket == StatusTicket.Finished)
            {
                var ticketUpdated = _ticketrepository.GetById(ticketDetail.TicketId);
                ticketUpdated.Result.ChangeStatusTicket(ticketDetail.StatusTicket);
            }
            await _ticketrepository.SaveChanges();
        }
    }
}
