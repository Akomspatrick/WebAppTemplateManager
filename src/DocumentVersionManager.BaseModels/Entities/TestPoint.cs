namespace DocumentVersionManager.BaseModels.Entities
{
    public class TestPoint : BaseEntity
    {
        public static TestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int testId, int weight)
        {
            return new TestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                TestPointId = weight,
                //TestId = testId,
                GuidId = capacityTestPointGuid
            };
        }

        public static TestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int weight)
        {
            return new TestPoint()
            {
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                TestPointId = weight,
                GuidId = capacityTestPointGuid
            };
        }
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public int Capacity { get; init; }
        public int TestPointId { get; init; }
        // public int TestId { get; init; } // should auto increase
        // public Guid CapacityTestPointGuid { get; init; }
        public Specification Specification { get; set; }


    }
}
