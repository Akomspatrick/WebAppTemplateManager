using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial  : BaseEntity
        {
            public string ShellMaterialName    { get; init; }  = string.Empty; 
            private  IList <Specification> _CapacitySpecifications { get;  set;}  = new List<Specification>();
            public  IEnumerable<Specification> CapacitySpecifications => _CapacitySpecifications.AsReadOnly();
            public Guid GuidId    { get; init; } 
        }
}