namespace DocumentVersionManager.Contracts.ResponseDTO
{
    public record ModelTypeResponseDTO(Guid ModelTypesId, string ModelTypesName, ICollection<ModelResponseDTO> Models);
}
