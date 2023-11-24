using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelTypes  : BaseEntity
        {
            public string ModelTypesName    { get; init; }  = string.Empty; 
            public ICollection<Model> Models { get; set;}
            public Guid GuidId    { get; init; } 
        }
}