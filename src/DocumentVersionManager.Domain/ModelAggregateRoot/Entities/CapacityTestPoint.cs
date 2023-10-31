using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class CapacityTestPoint : BaseEntity
    {
        public static CapacityTestPoint Create(Guid capacityTestPointGuid,string modelName, int modelVersionId, int capacity, int weight)
        {
            return new CapacityTestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                Weight = weight,
             //   TestId = testId,
                CapacityTestPointGuid = capacityTestPointGuid
            };
        }

        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public int Capacity { get; init; }
        public int Weight { get; init; }
        public int TestId { get; init; } // should auto increase
        public Guid CapacityTestPointGuid { get; init; }
        public CapacitySpecification CapacitySpecification { get; set; }


    }
}
