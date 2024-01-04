namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelTypeGroupGetRequestByGuidDTO(Guid guid);
    public  record ModelTypeGroupGetRequestByIdDTO(Object Value);
    public  record ModelTypeGroupGetRequestDTO(Object Value);
    public  record ModelTypeGroupCreateRequestDTO(Guid GuidId,Object Value );
    public  record ModelTypeGroupUpdateRequestDTO(Object Value);
    public  record ModelTypeGroupDeleteRequestDTO(Guid guid);
}