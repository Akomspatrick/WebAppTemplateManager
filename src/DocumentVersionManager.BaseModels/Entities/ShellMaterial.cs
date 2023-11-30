namespace DocumentVersionManager.BaseModels.Entities
{
    public class ShellMaterial : BaseEntity
    {
        public string ShellMaterialName { get; init; } = string.Empty;

        // public Guid ShellMaterialGuid { get; init; }
        public ICollection<Specification> CapacitySpecifications { get; set; }

        public static ShellMaterial Create(Guid shellMaterialGuid, string name, int alloy)
        {
            return new ShellMaterial()
            {
                ShellMaterialName = name,

                GuidId = shellMaterialGuid,

            };

        }

    }
}
