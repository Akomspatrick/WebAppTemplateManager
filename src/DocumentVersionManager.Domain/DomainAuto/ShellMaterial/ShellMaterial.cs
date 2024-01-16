using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial  : BaseEntity
    {
        private ShellMaterial(){}
        public string ShellMaterialName    { get; init; }  = string.Empty; 
        public Boolean Alloy    { get; init; } 
        private  List <ModelVersion> _ModelVersions { get;  set;}  = new List<ModelVersion>();
        public  IReadOnlyCollection<ModelVersion> ModelVersions => _ModelVersions;
        public Guid GuidId    { get; init; } 
        
        public static ShellMaterial Create(string  shellMaterialName, Boolean  alloy, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ShellMaterial Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ShellMaterialName = shellMaterialName ,
            Alloy = alloy ,
            GuidId = guidId ,
        };
    }
    }
}