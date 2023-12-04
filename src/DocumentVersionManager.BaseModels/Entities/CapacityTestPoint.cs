namespace DocumentVersionManager.BaseModels.Entities
{
    public class CapacityTestPoint : BaseEntity
    {
        public static CapacityTestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int testId, int weight)
        {
            return new CapacityTestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                TestPoint = weight,
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
                TestPoint = weight,
                GuidId = capacityTestPointGuid
            };
        }
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public int Capacity { get; init; }
        public int TestPoint { get; init; }
        public int TestId { get; init; } // should auto increase
                                         // public Guid CapacityTestPointGuid { get; init; }
        public Specification Specification { get; set; }


    }
}
