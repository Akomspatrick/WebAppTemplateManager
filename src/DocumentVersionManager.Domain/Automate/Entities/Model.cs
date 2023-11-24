using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class Model  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public string ModelTypesName    { get; init; }  = string.Empty; 
            public ModelTypes ModelTypes    { get; init; } 
            public Guid GuidId    { get; init; } 
        }
}