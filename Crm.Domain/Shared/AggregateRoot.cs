using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Domain.Shared
{
    /// <summary>
    /// Set Aggregateroot for Entities that define as Aggregate
    /// Aggregate root need to inherit from BaseEntity
    /// </summary>
    public class AggregateRoot : BaseEntity
    {
        /// <summary>
        /// define list of BaseDomainEvent that need to use in Domain
        /// we define two list of BaseDomainEvent that first for Write
        /// and second for read and not mapped in database
        /// </summary>
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

        [NotMapped]
        public List<BaseDomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// this function add new domain event to list BaseDomainEvent
        /// </summary>
        /// <param name="eventItem">eventItem is type of BaseDomainEvent that add to domain event </param>
        public void AddDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }
        /// <summary>
        /// this function remove eventItem from list of BaseDomainEvent
        /// list BasedomainEvent can be null 
        /// </summary>
        /// <param name="eventItem">eventItem is type of BaseDomainEvent that wanna to remove from BaseDomainEvent</param>
        public void RemoveDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}
