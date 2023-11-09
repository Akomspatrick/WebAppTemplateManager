namespace DocumentVersionManager.Application.Contracts.RequestDTO
{


    //    public record ApplicationModelRequestDTO(string ModelId);

    //    public record ApplicationModelCreateDTO(string ModelId, string modelTypesId, string ModelName);
    //    public record ApplicationModelUpdateDTO(string ModelId, string modelTypesId, string ModelName);
    //    public record ApplicationModelDeleteDTO(string ModelId);
    //

    public record ApplicationModelRequestDTOByGuidId(Guid ModelId);
    public record ApplicationModelRequestDTO(string ModelName);
    public record ApplicationModelCreateDTO( Guid ModelId, string ModelName, string ModelTypesName);
    public record ApplicationModelUpdateDTO(Guid ModelId,  string ModelName, string ModelTypesName);
    public record ApplicationModelDeleteDTO(Guid ModelId);

}
