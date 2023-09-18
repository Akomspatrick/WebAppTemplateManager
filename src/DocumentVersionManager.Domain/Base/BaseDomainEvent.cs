using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Base
{
    public class BaseDomainEvent :INotification
    {
        public virtual Guid EventId { get; init; }
        public virtual DateTime CreatedOn { get; init; }    
        public virtual DateTime CreatedOnUtc { get; init; }

        public BaseDomainEvent()
        {
            CreatedOn = DateTime.UtcNow;
            CreatedOnUtc = DateTime.UtcNow;
            EventId = Guid.NewGuid();
        }
    }
}
