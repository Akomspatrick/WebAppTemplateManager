namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ModelTypeGetRequestByGuidDTO(Guid guid);
    public  record ModelTypeGetRequestByIdDTO(Object Value);
    public  record ModelTypeGetRequestDTO(Object Value);
    public  record ModelTypeCreateRequestDTO(Guid GuidId,Object Value );
    public  record ModelTypeUpdateRequestDTO(Object Value);
    public  record ModelTypeDeleteRequestDTO(Guid guid);
}