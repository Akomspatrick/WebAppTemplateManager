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
    public record ModelTypeCreateDTO(string modelTypesName);
    public record ModelTypeUpdateDTO(Guid modelTypesId, string modelTypesName);
    public record ModelTypeRequestDTOById(Guid modelTypesId);
    public record ModelTypeRequestDTO(string modelTypesName);
    public record ModelTypeDeleteDTO(Guid modelTypesId);
}
