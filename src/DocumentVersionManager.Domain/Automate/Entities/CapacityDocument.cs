namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class CapacityDocument  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public int Capacity    { get; init; } 
            public string DocumentPath    { get; init; }  = string.Empty; 
            public Guid GuidId    { get; init; } 
        }
}