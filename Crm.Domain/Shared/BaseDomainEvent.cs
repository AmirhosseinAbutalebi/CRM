using MediatR;
namespace Crm.Domain.Shared
{
    public class BaseDomainEvent : INotification
    {
        public BaseDomainEvent()
        {
            CreationDate = new DateTime();
        }
        public DateTime CreationDate { get; protected set; }
    }
}
