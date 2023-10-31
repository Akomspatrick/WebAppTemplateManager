using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class ShellMaterial:BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public int Alloy { get; init; }
        public Guid ShellMaterialGuid { get; init; }
       // public ICollection<CapacitySpecification> CapacitySpecifications { get; set; }

        public static ShellMaterial Create( Guid shellMaterialGuid,string name, int alloy)
        {
            return new ShellMaterial()
            {
                Name = name,
                Alloy = alloy,
                ShellMaterialGuid = shellMaterialGuid,

            };

        }

    }
}
