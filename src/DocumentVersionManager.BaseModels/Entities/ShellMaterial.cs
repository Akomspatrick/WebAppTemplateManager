namespace DocumentVersionManager.BaseModels.Entities
{
    public class ShellMaterial : BaseEntity
    {
        public string ShellMaterialName { get; init; } = string.Empty;

        public bool Alloy { get; init; }
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
