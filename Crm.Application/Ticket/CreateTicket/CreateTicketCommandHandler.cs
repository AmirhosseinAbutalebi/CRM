using Crm.Domain.TicketAgg;
using Crm.Domain.TicketAgg.Enums;
using Crm.Domain.TicketAgg.Repository;
using Crm.Domain.UserAgg.Enums;
using Crm.Domain.UserAgg.Repository;
using MediatR;

namespace Crm.Application.Ticket.Create
{
    internal class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        
        private readonly ITicketRepository _repostiory;
      
        private readonly IUserRepository _userRepostiory;

        public CreateTicketCommandHandler(ITicketRepository repostiory, IUserRepository userRepostiory)
        {
            _repostiory = repostiory;
            _userRepostiory = userRepostiory;
        }

        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            if (!_userRepostiory.UserExists(request.UserIdReciver))
                throw new InvalidDataException("چنین کاربری برای ایجاد تیکت وجود ندارد");
            
            var reciver = await _userRepostiory.GetAsync(request.UserIdReciver);
            
            if (reciver.Role != LevelUser.Teacher)
                throw new InvalidDataException("شما فقط می توانید به اساتید تیکت بزنید لطفا یوزرنیم مربوطه را وارد نماید");

            var user = await _userRepostiory.GetAsync(request.UserIdSender);

            var ticket = new Tickets(user.Id,request.UserIdReciver,request.Title,request.Description);
            _repostiory.Add(ticket);
            await _repostiory.Save();

            var ticketDetail = new TicketDetail(request.Description, request.UserIdSender,
                request.UserIdReciver, StatusRead.other, StatusTicket.During, ticket.Id);

            ticket.AddticketDetail(ticketDetail);
            await _repostiory.Save();
        }
    }
}
