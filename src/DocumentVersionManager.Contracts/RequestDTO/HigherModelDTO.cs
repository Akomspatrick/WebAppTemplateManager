using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{

    public record HigherModelDTO(string HigherModelName, string HigherModelDescription, string ProductId, int Capacity);
}
