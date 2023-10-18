using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{

    public record ModelRequestDTO(string ModelId);

    public record ModelCreateDTO(string ModelId, string ModelTypeId, string ModelName);
    public record ModelUpdateDTO(string ModelId, string ModelTypeId, string ModelName);
    public record ModelDeleteDTO(string ModelId);
}
