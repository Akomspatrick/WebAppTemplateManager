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
    public record ModelTypeCreateDTO(string ModelTypeName);
    public record ModelTypeUpdateDTO(Guid ModelTypeId, string ModelTypeName);
    public record ModelTypeRequestByGuidDTO(Guid ModelTypeId);
    public record ModelTypeRequestByIdDTO(string ModelTypeId);
    public record ModelTypeRequestDTO(string ModelTypeName);
    public record ModelTypeDeleteDTO(Guid ModelTypeId);
}
