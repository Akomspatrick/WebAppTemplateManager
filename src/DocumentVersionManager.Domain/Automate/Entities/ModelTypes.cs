namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class ModelTypes  : BaseEntity
        {
            public string ModelTypesName    { get; init; }  = string.Empty; 
            public ICollection<Model> Models { get; set;}
            public Guid GuidId    { get; init; } 
        }
}