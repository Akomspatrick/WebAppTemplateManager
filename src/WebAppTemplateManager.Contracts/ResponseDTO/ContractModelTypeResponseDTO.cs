namespace WebAppTemplateManager.Contracts.ResponseDTO
{
    public record ModelTypeResponseDTO(Guid? ModelTypeId, string? ModelTypeName, string ModelTypeGroupName, ICollection<object>? Models);

}