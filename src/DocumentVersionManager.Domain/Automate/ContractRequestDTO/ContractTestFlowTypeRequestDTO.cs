namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record TestFlowTypeGetRequestByGuidDTO(Guid guid);
    public  record TestFlowTypeGetRequestByIdDTO(Object Value);
    public  record TestFlowTypeGetRequestDTO(Object Value);
    public  record TestFlowTypeCreateRequestDTO(Guid GuidId,Object Value );
    public  record TestFlowTypeUpdateRequestDTO(Object Value);
    public  record TestFlowTypeDeleteRequestDTO(Guid guid);
}