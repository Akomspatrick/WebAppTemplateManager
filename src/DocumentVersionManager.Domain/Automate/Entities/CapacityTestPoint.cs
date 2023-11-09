namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class CapacityTestPoint  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public int Capacity    { get; init; } 
            public int Weight    { get; init; } 
            public int TestId    { get; init; } 
            public CapacitySpecification CapacitySpecification    { get; init; } 
            public Guid GuidId    { get; init; } 
        }
}