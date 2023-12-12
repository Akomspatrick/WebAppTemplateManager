namespace DocumentVersionManager.Contracts.ResponseDTO
{
    public record ModelTypeResponseDTO(Guid ModelTypesId, string ModelTypeName, ICollection<ModelResponseDTO> Models);
}
