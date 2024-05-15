using MediatR;

namespace Crm.Application.Ticket.Create
{
    /// <summary>
    /// this class define for set data needed in command createTicket
    /// we use mediatR and DesignPattern mediator thus need inhert IRequest there
    /// </summary>
    public class CreateTicketCommand : IRequest
    {
        /// <summary>
        /// contructor CreateTicketCommand for set value in property
        /// </summary>
        /// <param name="userIdSender">long userid who send ticket</param>
        /// <param name="userIdReciver">long userid who recive ticket</param>
        /// <param name="title">string title for title Ticket</param>
        /// <param name="usernameSender">string username who send ticket</param>
        /// <param name="usernameReciver">string username who recive ticket</param>
        /// <param name="description">string description</param>
        public CreateTicketCommand(long userIdSender, long userIdReciver, string title,
            string usernameSender, string usernameReciver, string description)
        {
            UserIdSender = userIdSender;
            UserIdReciver = userIdReciver;
            Title = title;
            UsernameSender = usernameSender;
            UsernameReciver = usernameReciver;
            Description = description;
        }
        /// <summary>
        /// property UserIdSender type long with private set (just readonly)
        /// </summary>
        public long UserIdSender { get; private set; }
        /// <summary>
        /// property UserIdReciver type long with private set (just readonly)
        /// </summary>
        public long UserIdReciver { get; private set; }
        /// <summary>
        /// property Title type string with private set (just readonly)
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// property UsernameSender type string with private set (just readonly)
        /// </summary>
        public string UsernameSender { get; private set; }
        /// <summary>
        /// property UsernameReciver type string with private set (just readonly)
        /// </summary>
        public string UsernameReciver { get; private set; }
        /// <summary>
        /// property Description type string with private set (just readonly)
        /// </summary>
        public string Description { get; private set; }
    }
}
