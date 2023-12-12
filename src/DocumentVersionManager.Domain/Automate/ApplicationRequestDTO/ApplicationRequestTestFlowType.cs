namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestTestFlowTypeDTO();
    public  record ApplicationRequestTestFlowTypeByGuidDTO(Guid TestFlowTypeGuid);
    public  record ApplicationRequestTestFlowTypeByIdDTO(string TestFlowTypeId);
    public  record ApplicationCreateTestFlowTypeDTO();
    public  record ApplicationUpdateTestFlowTypeDTO(Guid TestFlowTypeGuid);
    public  record ApplicationDeleteTestFlowTypeDTO(Guid TestFlowTypeGuid);
}