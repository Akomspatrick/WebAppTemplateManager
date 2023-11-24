namespace DocumentVersionManager.Application.Contracts.ResponseDTO
{

    public record ApplicationModelTypeResponseDTO(Guid ModelTypesId, string ModelTypesName, ICollection<ApplicationModelResponseDTO> Models);
}
