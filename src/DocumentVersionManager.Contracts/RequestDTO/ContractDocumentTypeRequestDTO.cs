using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{
   // public record DocumentTypeDTO(string DocumentTypeName);
    public record DocumentTypeGetRequestByGuidDTO(Guid guid);
    public record DocumentTypeGetRequestByIdDTO(Object Value);
    public record DocumentTypeGetRequestDTO(Object Value);
    public record DocumentTypeCreateRequestDTO(Guid GuidId, Object Value);
    public record DocumentTypeUpdateRequestDTO(Object Value);
    public record DocumentTypeDeleteRequestDTO(Guid guid);
}
