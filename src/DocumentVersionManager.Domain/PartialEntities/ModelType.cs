using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelType  : BaseEntity
        {
            public string ModelTypeName    { get; init; }  = string.Empty; 
            private  List <Model> _Models { get;  set;}  = new List<Model>();
            public  IReadOnlyCollection<Model> Models => _Models;
            public Guid GuidId    { get; init; } 
        }
}