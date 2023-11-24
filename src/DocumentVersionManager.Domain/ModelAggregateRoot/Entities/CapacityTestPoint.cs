using DocumentVersionManager.DomainBase.Base;


namespace DocumentVersionManager.Domain.Entities
{
    public partial class CapacityTestPoint : BaseEntity
    {
        public static CapacityTestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int testId, int weight)
        {
            return new CapacityTestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                Weight = weight,
                TestId = testId,
                GuidId = capacityTestPointGuid
            };
        }

        public static CapacityTestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int weight)
        {
            return new CapacityTestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                Weight = weight,
                GuidId = capacityTestPointGuid
            };
        }


    }
}
