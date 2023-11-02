using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.ResponseDTO
{

        public record ModelResponseDTO(Guid ModelId, string ModelName, string ModelTypesName);
    
}
