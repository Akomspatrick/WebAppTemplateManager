namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelGetRequestByGuidDTO(Guid guid);
    public  record ModelGetRequestByIdDTO(Object Value);
    public  record ModelGetRequestDTO(Object Value);
    public  record ModelCreateRequestDTO(Guid GuidId,Object Value );
    public  record ModelUpdateRequestDTO(Object Value);
    public  record ModelDeleteRequestDTO(Guid guid);
}