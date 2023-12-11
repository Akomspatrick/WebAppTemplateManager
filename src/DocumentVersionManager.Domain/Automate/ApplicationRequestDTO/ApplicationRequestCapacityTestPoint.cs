namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestCapacityTestPointDTO();
    public  record ApplicationRequestCapacityTestPointByGuidDTO(Guid CapacityTestPointGuid);
    public  record ApplicationRequestCapacityTestPointByIdDTO(string CapacityTestPointId);
    public  record ApplicationCreateCapacityTestPointDTO();
    public  record ApplicationUpdateCapacityTestPointDTO(Guid CapacityTestPointGuid);
    public  record ApplicationDeleteCapacityTestPointDTO(Guid CapacityTestPointGuid);
}