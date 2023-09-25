using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class ShellMaterial
    {
        public string Name { get; init; } = string.Empty;
        public int Alloy { get; init; }


    }
}
