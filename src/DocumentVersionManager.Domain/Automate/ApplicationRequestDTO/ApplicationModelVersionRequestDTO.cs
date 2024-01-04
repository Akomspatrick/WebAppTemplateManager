namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationModelVersionGetRequestByGuidDTO(ModelVersionGetRequestByGuidDTO Value);
    public  record ApplicationModelVersionGetRequestByIdDTO(ModelVersionGetRequestByIdDTO Value);
    public  record ApplicationModelVersionGetRequestDTO(ModelVersionGetRequestDTO Value);
    public  record ApplicationModelVersionCreateRequestDTO(ModelVersionCreateRequestDTO Value );
    public  record ApplicationModelVersionUpdateRequestDTO(ModelVersionUpdateRequestDTO Value);
    public  record ApplicationModelVersionDeleteRequestDTO(ModelVersionDeleteRequestDTO Value);
}