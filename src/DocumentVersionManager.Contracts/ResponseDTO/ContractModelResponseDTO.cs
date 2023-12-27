namespace DocumentVersionManager.Contracts.ResponseDTO
{
    public record ModelResponseDTO(Guid GuidId, string ModelName, string ModelTypeName, ICollection<ModelVersionResponseDTO>? ModelVersions);
                  
}