using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestPoint  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public int Capacity    { get; init; } 
            public int TestPointId    { get; init; } 
            public Specification Specification    { get; init; } 
            public Guid GuidId    { get; init; } 
        }
}