namespace DocumentVersionManager.Contracts.ResponseDTO
{
    public record ModelTypeResponseDTO(Guid? ModelTypeId, string? ModelTypeName, string ModelTypeGroupName, ICollection<ModelResponseDTO>? Models);

}