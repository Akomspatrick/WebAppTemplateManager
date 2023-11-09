namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class Model  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public string ModelTypesName    { get; init; }  = string.Empty; 
            public ModelTypes ModelTypes    { get; init; } 
            public Guid GuidId    { get; init; } 
        }
}