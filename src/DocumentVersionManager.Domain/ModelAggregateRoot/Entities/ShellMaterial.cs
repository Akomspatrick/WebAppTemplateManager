using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class ShellMaterial : BaseEntity
    {


        public static ShellMaterial Create(Guid shellMaterialGuid, string name)
        {
            return new ShellMaterial()
            {
                ShellMaterialName = name,
                GuidId = shellMaterialGuid,

            };

        }

    }
}
