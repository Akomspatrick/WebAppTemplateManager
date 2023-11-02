using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{

    //public record ModelTypeCreateDTO(string modelTypesId, string modelTypesName);
    //public record ModelTypeUpdateDTO(string modelTypesId, string modelTypesName);
    //public record ModelTypeRequestDTO(string modelTypesId);
    //public record ModelTypeDeleteDTO(string modelTypesId);
    public record ModelTypeCreateDTO(string ModelTypesName);
    public record ModelTypeUpdateDTO(Guid ModelTypesId, string ModelTypesName);
    public record ModelTypeRequestDTOByGuidId(Guid ModelTypesId);
    public record ModelTypeRequestDTO(string ModelTypesName);
    public record ModelTypeDeleteDTO(Guid ModelTypesId);
}
