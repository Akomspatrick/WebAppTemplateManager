using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial  : BaseEntity
        {
            public string ShellMaterialName    { get; init; }  = string.Empty; 
            public Boolean Alloy    { get; init; } 
            private  List <ModelVersion> _ModelVersions { get;  set;}  = new List<ModelVersion>();
            public  IReadOnlyCollection<ModelVersion> ModelVersions => _ModelVersions;
            public Guid GuidId    { get; init; } 
        }
}