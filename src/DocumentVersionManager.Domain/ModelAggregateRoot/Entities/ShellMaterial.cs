using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial : BaseEntity
    {


        public static ShellMaterial Create(Guid shellMaterialGuid, string name, int alloy)
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
