using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelTypes  : BaseEntity
        {
            public string ModelTypesName    { get; init; }  = string.Empty; 
            private  List <Model> _Models { get;  set;}  = new List<Model>();
            public  IReadOnlyCollection<Model> Models => _Models;
            public Guid GuidId    { get; init; } 
        }
}