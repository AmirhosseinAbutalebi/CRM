using Crm.Domain.Shared;

namespace Crm.Domain.TicketAgg.Events
{
    /// <summary>
    /// define Event Create Ticket and inhret from BaseDomainEvent 
    /// </summary>
    public class CreateTicket : BaseDomainEvent
    {
        /// <summary>
        /// constructor CreateTicket and set value for property that define after
        /// beacuse all property are private set and readonly need to change value 
        /// with constructor
        /// </summary>
        /// <param name="userIdSender">Id person who send ticket</param>
        /// <param name="userIdReciver">Id person who recive ticket</param>
        /// <param name="title">title ticket</param>
        /// <param name="usernameSender">username person who send ticket</param>
        /// <param name="usernameReciver">username person who send ticket</param>
        /// <param name="description">description of ticket</param>
        public CreateTicket(long userIdSender, long userIdReciver, string title,
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
        /// property userIdSender with type long and private set for readonly
        /// </summary>
        public long UserIdSender { get; private set; }
        /// <summary>
        /// property UserIdReciver with type long and private set for readonly
        /// </summary>
        public long UserIdReciver { get; private set; }
        /// <summary>
        /// property Title ticket with type string and private set for readonly
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// property UsernameSender with type string for person who send ticket and private set for readonly
        /// </summary>
        public string UsernameSender { get; private set; }
        /// <summary>
        /// property UsernameReciver with type string for person who recive ticket and private set for readonly
        /// </summary>
        public string UsernameReciver { get; private set; }
        /// <summary>
        /// property Description with type string and private set for readonly
        /// </summary>
        public string Description { get; private set; }
    }
}
