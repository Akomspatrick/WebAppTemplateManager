using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.ResponseDTO
{

    public record ApplicationModelTypeResponseDTO(Guid ModelTypesId, string ModelTypesName, ICollection<ApplicationModelResponseDTO> Models);
}
