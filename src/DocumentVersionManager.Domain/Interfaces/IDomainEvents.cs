using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IDomainEvents
    {
        IReadOnlyList<BaseDomainEvent> DomainEvents { get; }
        void AddDomainEvent(BaseDomainEvent domainEvent);
        void RemoveDomainEvent(BaseDomainEvent domainEvent);
        void AddDomainEvents(IEnumerable<BaseDomainEvent> domainEvents);
        void RemoveDomainEvents(IEnumerable<BaseDomainEvent> domainEvents);
        void ClearDomainEvents();

    }
}
