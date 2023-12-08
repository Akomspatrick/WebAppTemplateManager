using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial  : BaseEntity
        {
            public string ShellMaterialName    { get; init; }  = string.Empty; 
            public Boolean Alloy    { get; init; } 
            private  List <Specification> _CapacitySpecifications { get;  set;}  = new List<Specification>();
            public  IReadOnlyCollection<Specification> CapacitySpecifications => _CapacitySpecifications;
            public Guid GuidId    { get; init; } 
        }
}