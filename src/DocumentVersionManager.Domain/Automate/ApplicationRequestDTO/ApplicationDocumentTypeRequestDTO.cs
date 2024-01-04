namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationDocumentTypeGetRequestByGuidDTO(DocumentTypeGetRequestByGuidDTO Value);
    public  record ApplicationDocumentTypeGetRequestByIdDTO(DocumentTypeGetRequestByIdDTO Value);
    public  record ApplicationDocumentTypeGetRequestDTO(DocumentTypeGetRequestDTO Value);
    public  record ApplicationDocumentTypeCreateRequestDTO(DocumentTypeCreateRequestDTO Value );
    public  record ApplicationDocumentTypeUpdateRequestDTO(DocumentTypeUpdateRequestDTO Value);
    public  record ApplicationDocumentTypeDeleteRequestDTO(DocumentTypeDeleteRequestDTO Value);
}