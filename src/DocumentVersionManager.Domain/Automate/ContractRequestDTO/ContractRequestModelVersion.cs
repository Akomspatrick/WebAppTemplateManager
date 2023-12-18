namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelVersionGetRequestByGuidDTO(Guid guid);
    public  record ModelVersionGetRequestByIdDTO(Object Value);
    public  record ModelVersionGetRequestDTO(Object Value);
    public  record ModelVersionCreateRequestDTO(Guid GuidId,Object Value );
    public  record ModelVersionUpdateRequestDTO(Object Value);
    public  record ModelVersionDeleteRequestDTO(Guid guid);
}