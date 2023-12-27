namespace DocumentVersionManager.Contracts.ResponseDTO
{
    public record ModelTypeResponseDTO(Guid? ModelTypeId, string? ModelTypeName, ICollection<ModelResponseDTO>? Models);

}