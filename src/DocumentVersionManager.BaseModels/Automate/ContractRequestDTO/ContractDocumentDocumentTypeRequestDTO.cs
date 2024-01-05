namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record DocumentDocumentTypeGetRequestByGuidDTO(Guid guid);
    public  record DocumentDocumentTypeGetRequestByIdDTO(Object Value);
    public  record DocumentDocumentTypeGetRequestDTO(Object Value);
    public  record DocumentDocumentTypeCreateRequestDTO(Guid GuidId,Object Value );
    public  record DocumentDocumentTypeUpdateRequestDTO(Object Value);
    public  record DocumentDocumentTypeDeleteRequestDTO(Guid guid);
}