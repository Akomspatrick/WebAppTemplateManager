namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationModelGetRequestByGuidDTO(ModelGetRequestByGuidDTO Value);
    public  record ApplicationModelGetRequestByIdDTO(ModelGetRequestByIdDTO Value);
    public  record ApplicationModelGetRequestDTO(ModelGetRequestDTO Value);
    public  record ApplicationModelCreateRequestDTO(ModelCreateRequestDTO Value );
    public  record ApplicationModelUpdateRequestDTO(ModelUpdateRequestDTO Value);
    public  record ApplicationModelDeleteRequestDTO(ModelDeleteRequestDTO Value);
}