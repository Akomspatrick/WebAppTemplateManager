using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class Model  : BaseEntity
        {
            public string ModelName    { get; init; }  = string.Empty; 
            public string ModelTypesName    { get; init; }  = string.Empty; 
            public ModelType ModelTypes    { get; init; } 
            private  List <ModelVersion> _ModelVersions { get;  set;}  = new List<ModelVersion>();
            public  IReadOnlyCollection<ModelVersion> ModelVersions => _ModelVersions;
            public Guid GuidId    { get; init; } 
        }
}