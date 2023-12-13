using DocumentVersionManager.DomainBase.Base;


namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestPoint : BaseEntity
    {
        private TestPoint() { }
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




    }
}
