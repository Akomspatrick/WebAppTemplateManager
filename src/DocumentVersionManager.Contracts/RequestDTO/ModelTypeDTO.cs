using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{

    public record ModelTypeCreateDTO(string ModelTypeId, string ModelTypeName);
    public record ModelTypeUpdateDTO(string ModelTypeId, string ModelTypeName);
    public record ModelTypeRequestDTO(string ModelTypeId);
    public record ModelTypeDeleteDTO(string ModelTypeId);

}
