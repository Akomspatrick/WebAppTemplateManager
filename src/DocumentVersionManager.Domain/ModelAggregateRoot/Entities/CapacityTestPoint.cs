using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class CapacityTestPoint
    {
        public string ModelName { get; init; } = string.Empty;
        public int Capacity { get; init; }
        public int Weight { get; init; }
        public int TestId { get; init; } // should auto increase


    }
}
