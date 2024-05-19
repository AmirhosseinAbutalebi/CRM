namespace Crm.Query.Tickets.DTOs
{
    /// <summary>
    /// define dto for use in query
    /// </summary>
    public class TicketDto
    {
        /// <summary>
        /// long id for ticket dto
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// long useridsender for show person who send ticket
        /// </summary>
        public long UserIdSender { get; set; }
        /// <summary>
        /// long useridreciver for show person who recive ticket
        /// </summary>
        public long UserIdReciver { get; set; }
        /// <summary>
        ///  string title for show title ticket
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// string usernamesender for person who send ticket
        /// </summary>
        public string UsernameSender { get; set; }
        /// <summary>
        /// string usernamereciver for person who recive ticket
        /// </summary>
        public string UsernameReciver { get; set; }
        /// <summary>
        /// string description for show description ticket
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// add string Fullname for show fullname who send or recive ticket
        /// </summary>
        public string FullName { get; set; }
    }
}
