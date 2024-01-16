using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class ShellMaterial : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false, true)]
        public string ShellMaterialName { get; init; } = string.Empty;

        public bool Alloy { get; init; }
        // public ICollection<Specification> CapacitySpecifications { get; set; }
        public ICollection<ModelVersion> ModelVersions { get; set; } = new List<ModelVersion>();


    }
}
