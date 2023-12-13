namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationDocumentGetRequestByGuidDTO(DocumentGetRequestByGuidDTO Value);
    public  record ApplicationDocumentGetRequestByIdDTO(DocumentGetRequestByIdDTO Value);
    public  record ApplicationDocumentGetRequestDTO(DocumentGetRequestDTO Value);
    public  record ApplicationDocumentCreateRequestDTO(DocumentCreateRequestDTO Value );
    public  record ApplicationDocumentUpdateRequestDTO(DocumentUpdateRequestDTO Value);
    public  record ApplicationDocumentDeleteRequestDTO(DocumentDeleteRequestDTO Value);
}