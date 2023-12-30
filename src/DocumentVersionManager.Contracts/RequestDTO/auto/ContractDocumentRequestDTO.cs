namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record DocumentGetRequestByGuidDTO(Guid guid);
    public  record DocumentGetRequestByIdDTO(Object Value);
    public  record DocumentGetRequestDTO(Object Value);
    public  record DocumentCreateRequestDTO(Guid GuidId,Object Value );
    public  record DocumentUpdateRequestDTO(Object Value);
    public  record DocumentDeleteRequestDTO(Guid guid);
}