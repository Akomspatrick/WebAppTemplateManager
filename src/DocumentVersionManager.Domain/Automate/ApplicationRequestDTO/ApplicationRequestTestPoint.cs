namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestTestPointDTO();
    public  record ApplicationRequestTestPointByGuidDTO(Guid TestPointGuid);
    public  record ApplicationRequestTestPointByIdDTO(string TestPointId);
    public  record ApplicationCreateTestPointDTO();
    public  record ApplicationUpdateTestPointDTO(Guid TestPointGuid);
    public  record ApplicationDeleteTestPointDTO(Guid TestPointGuid);
}