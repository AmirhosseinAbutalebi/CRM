using MediatR;

namespace Crm.Application.Ticket.Create
{
    public class CreateTicketCommand : IRequest
    {
        public CreateTicketCommand(long userIdSender, long userIdReciver, string title, string description)
        {
            UserIdSender = userIdSender;
            UserIdReciver = userIdReciver;
            Title = title;
            Description = description;
        }
        public long UserIdSender { get; private set; }
        
        public long UserIdReciver { get; private set; }
      
        public string Title { get; private set; }
        
        public string Description { get; private set; }
    }
}
