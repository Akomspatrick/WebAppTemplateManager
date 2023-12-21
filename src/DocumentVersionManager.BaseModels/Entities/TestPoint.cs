namespace DocumentVersionManager.BaseModels.Entities
{
    public class TestPoint : BaseEntity
    {
        //public static TestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int testId, int weight)
        //{
        //    return new TestPoint()
        //    {
        //        ModelName = modelName,
        //        ModelVersionId = modelVersionId,
        //        Capacity = capacity,
        //        TestPointId = weight,
        //        //TestId = testId,
        //        GuidId = capacityTestPointGuid
        //    };
        //}

        //public static TestPoint Create(Guid capacityTestPointGuid, string modelName, int modelVersionId, int capacity, int weight)
        //{
        //    return new TestPoint()
        //    {
        //        ModelName = modelName,
        //        ModelVersionId = modelVersionId,
        //        Capacity = capacity,
        //        TestPointId = weight,
        //        GuidId = capacityTestPointGuid
        //    };
        //}
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public int CapacityTestPoint { get; init; }// these are the test points/weights for the capacity test
                                                   // we dont need to specify capacity again because the Modelversion already has it

        public ModelVersion ModelVersion { get; set; }

    }
}
