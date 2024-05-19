using Crm.Domain.Shared;
using Crm.Domain.TicketDetailAgg.Enums;
namespace Crm.Domain.TicketAgg
{
    /// <summary>
    /// this class is root and for define entity tickets
    /// we dont have essential method and this project is basic
    /// then we dont have mehtod in this domain
    /// </summary>
    public class Tickets : AggregateRoot
    {
        /// <summary>
        /// constructor of tickets for set value for properties
        /// that define readonly
        /// </summary>
        /// <param name="userIdSender">Id person who send ticket</param>
        /// <param name="userIdReciver">Id person who recive ticket</param>
        /// <param name="title">title ticket</param>
        /// <param name="usernameSender">username person who send ticket</param>
        /// <param name="usernameReciver">username person who send ticket</param>
        /// <param name="description">description of ticket</param>
        public Tickets(long userIdSender, long userIdReciver, string title,
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
        /// need to define second constructor for Entity framework
        /// </summary>
        private Tickets()
        {
            
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
        /// <summary>
        /// this property is type of enum and check status ticket and private ser for readonly
        /// status ticket can be 0 = during and 1 = finished
        /// </summary>
        public StatusTicket StatusTicket { get; private set; }

        public void ChangeStatusTicket(StatusTicket statusTicket)
        {
            StatusTicket = statusTicket;
        }
    }
}
