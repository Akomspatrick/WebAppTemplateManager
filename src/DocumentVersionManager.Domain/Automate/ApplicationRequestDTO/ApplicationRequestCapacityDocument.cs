namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestCapacityDocumentDTO();
    public  record ApplicationRequestCapacityDocumentByGuidDTO(Guid CapacityDocumentGuid);
    public  record ApplicationRequestCapacityDocumentByIdDTO(string CapacityDocumentId);
    public  record ApplicationCreateCapacityDocumentDTO();
    public  record ApplicationUpdateCapacityDocumentDTO(Guid CapacityDocumentGuid);
    public  record ApplicationDeleteCapacityDocumentDTO(Guid CapacityDocumentGuid);
}