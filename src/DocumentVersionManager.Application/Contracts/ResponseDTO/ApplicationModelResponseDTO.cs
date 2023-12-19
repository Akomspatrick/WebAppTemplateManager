using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.ResponseDTO
{
    // public record ApplicationModelResponseDTO(string ModelId, string modelTypesId, string ModelName);
    // public record ApplicationModelResponseDTO(Guid ModelId,  string ModelName, string ModelTypesName);
    public record ApplicationModelResponseDTO(Guid GuidId, string ModelName, string ModelTypeName, ICollection<ApplicationModelVersionResponseDTO>? ModelVersions);


}
