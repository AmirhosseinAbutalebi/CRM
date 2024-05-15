using MediatR;

namespace Crm.Domain.Shared
{
    /// <summary>
    /// create BaseDomainEvent for event that use in Domain and 
    /// inheritance from INofication (MediatR) for publish event and use it in notification
    /// </summary>
    public class BaseDomainEvent : INotification
    {
        /// <summary>
        /// constructor BaseDomainEvent and set new data
        /// in CreationDate when call BaseDomainEvent with type DateTime
        /// </summary>
        public BaseDomainEvent()
        {
            CreationDate = new DateTime();
        }
        /// <summary>
        /// property CreationDate for date of event occure
        /// and define as protected set till change it just
        /// in class inhert from BaseDomainEvent
        /// </summary>
        public DateTime CreationDate { get; protected set; }
    }
}
