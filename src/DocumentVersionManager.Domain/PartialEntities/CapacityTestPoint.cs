using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class CapacityTestPoint  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public int Capacity    { get; init; } 
            public int TestPoint    { get; init; } 
            public int TestId    { get; init; } 
            public Specification Specification    { get; init; } 
            public Guid GuidId    { get; init; } 
        }
}