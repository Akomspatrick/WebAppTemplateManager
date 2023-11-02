using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{

    //public record ModelRequestDTO(string ModelId);

    //public record ModelCreateDTO(string ModelId, string modelTypesId, string ModelName);
    //public record ModelUpdateDTO(string ModelId, string modelTypesId, string ModelName);
    //public record ModelDeleteDTO(string ModelId);
    public record ModelDTOByGuidId(Guid ModelId);
    public record ModelDTO(string ModelName);
    public record ModelCreateDTO(Guid ModelId, string ModelName, string ModelTypesName);
    public record ModelUpdateDTO(Guid ModelId, string ModelName, string ModelTypesName);
    public record ModelDeleteDTO(Guid ModelId);
    
}
