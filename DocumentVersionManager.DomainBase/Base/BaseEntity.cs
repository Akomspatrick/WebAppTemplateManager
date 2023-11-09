
using DocumentVersionManager.DomainBase.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentVersionManager.DomainBase.Base
{
    public abstract class BaseEntity : IDomainEvents
    {

        public Guid  GuidId { get; set; } = default;

        private readonly List<BaseDomainEvent> _domainEvents = new();
        [NotMapped]

        public IReadOnlyList<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseDomainEvent domainEvent) => _domainEvents.Add(domainEvent);


        public void AddDomainEvents(IEnumerable<BaseDomainEvent> domainEvents) => _domainEvents.AddRange(domainEvents);

        public void ClearDomainEvents() => _domainEvents.Clear();

        public void RemoveDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void RemoveDomainEvents(IEnumerable<BaseDomainEvent> domainEvents)
        {
            throw new NotImplementedException();
        }
    }


    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; } = default;
    }
}
