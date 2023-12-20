using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class TestPoint  : BaseEntity
    {
        private TestPoint(){}
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public int Capacity    { get; init; } 
            public int TestPointId    { get; init; } 
            public ModelVersion ModelVersion    { get; init; } 
            public Guid GuidId    { get; init; } 
        
        public static TestPoint Create(string  modelName, int  modelVersionId, int  capacity, int  testPointId, Guid  guidId)
        =>new()
        {
            ModelName = modelName ,
            ModelVersionId = modelVersionId ,
            Capacity = capacity ,
            TestPointId = testPointId ,
            GuidId = guidId ,
        };
    }
}