using Crm.Domain.TicketAgg;
using Crm.Domain.TicketAgg.Repository;
using Crm.Domain.TicketDetailAgg.Enums;
using Crm.Domain.TicketDetailAgg.Repository;
using Crm.Domain.UserAgg.Enums;
using Crm.Domain.UserAgg.Repository;
using MediatR;

namespace Crm.Application.Ticket.Create
{
    /// <summary>
    /// this class handle createticketcommand and need to inhert IRequstHandler<> with dto that define for it
    /// and then handle instructure command in method Handle and need to define as internal class
    /// </summary>
    internal class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        /// <summary>
        /// use Ticket repository
        /// </summary>
        private readonly ITicketRepository _repostiory;
        /// <summary>
        /// use user repository
        /// </summary>
        private readonly IUserRepository _userRepostiory;
        /// <summary>
        /// use ticketdetail repository
        /// </summary>
        private readonly ITicketDetailRepository _ticketDetailRepository;

        /// <summary>
        /// constructor of createticketcommandhandler
        /// </summary>
        /// <param name="repostiory">set ticket repository</param>
        /// <param name="userRepostiory">set user repository</param>
        /// <param name="ticketDetailRepository">set ticketdetail repsitory</param>
        public CreateTicketCommandHandler(ITicketRepository repostiory, IUserRepository userRepostiory,
            ITicketDetailRepository ticketDetailRepository)
        {
            _repostiory = repostiory;
            _userRepostiory = userRepostiory;
            _ticketDetailRepository = ticketDetailRepository;
        }

        /// <summary>
        /// infrastructure of command in this method 
        /// </summary>
        /// <param name="request"> data needed and get in CreateTicketCommand</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns> task and save data in database</returns>
        /// <exception cref="InvalidDataException">for show username isn't exists</exception>
        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            ///check user with this username exist or not
            if (!_userRepostiory.UserExists(request.UsernameReciver))
                throw new InvalidDataException("چنین کاربری برای ایجاد تیکت وجود ندارد");
            
            ///get user 
            var reciver = _userRepostiory.GetByUserName(request.UsernameReciver);
            
            ///check user is teacher or not
            if (reciver.Result.Role != LevelUser.Teacher)
                throw new InvalidDataException("شما فقط می توانید به اساتید تیکت بزنید لطفا یوزرنیم مربوطه را وارد نماید");

            ///get id user for save ticket
            var user = _userRepostiory.GetById(request.UserIdSender);

            /// add ticket
            var ticket = new Tickets(user.Result.Id,request.UserIdReciver,request.Title,
                user.Result.UserName, request.UsernameReciver, request.Description);
            _repostiory.Add(ticket);
            await _repostiory.SaveChanges();

            /// add this ticket to ticket detail too
            var ticketDetail = new Domain.TicketDetailAgg.TicketDetail(request.Description, request.UsernameSender,
                request.UsernameReciver, StatusRead.other, StatusTicket.During, ticket.Id);
            _ticketDetailRepository.Add(ticketDetail);
            await _repostiory.SaveChanges();
        }
    }
}
