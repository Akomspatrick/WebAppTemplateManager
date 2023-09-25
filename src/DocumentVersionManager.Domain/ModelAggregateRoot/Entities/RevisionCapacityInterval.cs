using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class RevisionCapacityInterval
    {
        public int Capacity { get; init; }
        public DateTime Timestamp { get; init; }

        public string DocumentName { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;

         public int RevisionNumber { get; init; }



    }
}
