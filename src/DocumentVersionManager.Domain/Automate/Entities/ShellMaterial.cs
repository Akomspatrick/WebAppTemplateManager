namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class ShellMaterial  : BaseEntity
        {
            public string ShellMaterialName    { get; init; }  = string.Empty; 
            public int Alloy    { get; init; } 
            public ICollection<CapacitySpecification> CapacitySpecifications { get; set;}
            public Guid GuidId    { get; init; } 
        }
}