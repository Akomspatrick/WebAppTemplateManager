using DocumentVersionManager.Contracts.ResponseDTO;

namespace DocumentVersionManager.Application.Contracts.ResponseDTO
{

    public record ApplicationModelTypeResponseDTO(Guid ModelTypeId, string ModelTypeName, ICollection<ApplicationModelResponseDTO> Models);
  
}
