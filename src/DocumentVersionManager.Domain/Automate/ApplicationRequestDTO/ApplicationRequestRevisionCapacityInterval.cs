namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestRevisionCapacityIntervalDTO();
    public  record ApplicationRequestRevisionCapacityIntervalByGuidDTO(Guid RevisionCapacityIntervalGuid);
    public  record ApplicationRequestRevisionCapacityIntervalByIdDTO(string RevisionCapacityIntervalId);
    public  record ApplicationCreateRevisionCapacityIntervalDTO();
    public  record ApplicationUpdateRevisionCapacityIntervalDTO(Guid RevisionCapacityIntervalGuid);
    public  record ApplicationDeleteRevisionCapacityIntervalDTO(Guid RevisionCapacityIntervalGuid);
}