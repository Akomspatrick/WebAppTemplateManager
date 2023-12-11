namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestRevisionDTO();
    public  record ApplicationRequestRevisionByGuidDTO(Guid RevisionGuid);
    public  record ApplicationRequestRevisionByIdDTO(string RevisionId);
    public  record ApplicationCreateRevisionDTO();
    public  record ApplicationUpdateRevisionDTO(Guid RevisionGuid);
    public  record ApplicationDeleteRevisionDTO(Guid RevisionGuid);
}