using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelTypes  : BaseEntity
        {
            public string ModelTypesName    { get; init; }  = string.Empty; 
            private  IList <Model> _Models { get;  set;}  = new List<Model>();
            public  IEnumerable<Model> Models => _Models.AsReadOnly();
            public Guid GuidId    { get; init; } 
        }
}