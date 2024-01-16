using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestPoint  : BaseEntity
    {
        private TestPoint(){}
        public string ModelName    { get; init; }  = string.Empty; 
        public int ModelVersionId    { get; init; } 
        public int CapacityTestPoint    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        public Guid GuidId    { get; init; } 
        
        public static TestPoint Create(string  modelName, int  modelVersionId, int  capacityTestPoint, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"TestPoint Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelName = modelName ,
            ModelVersionId = modelVersionId ,
            CapacityTestPoint = capacityTestPoint ,
            GuidId = guidId ,
        };
    }
    }
}