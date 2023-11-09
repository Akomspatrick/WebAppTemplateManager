namespace DocumentVersionManager.BaseModels.Entities
{
    public class ShellMaterial:BaseEntity
    {
        public string ShellMaterialName { get; init; } = string.Empty;
        public int Alloy { get; init; }
       // public Guid ShellMaterialGuid { get; init; }
        public ICollection<CapacitySpecification> CapacitySpecifications { get; set; }

        public static ShellMaterial Create( Guid shellMaterialGuid,string name, int alloy)
        {
            return new ShellMaterial()
            {
                ShellMaterialName = name,
                Alloy = alloy,
                GuidId = shellMaterialGuid,

            };

        }

    }
}
