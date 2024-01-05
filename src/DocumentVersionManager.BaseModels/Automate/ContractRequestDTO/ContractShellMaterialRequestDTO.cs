namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ShellMaterialGetRequestByGuidDTO(Guid guid);
    public  record ShellMaterialGetRequestByIdDTO(Object Value);
    public  record ShellMaterialGetRequestDTO(Object Value);
    public  record ShellMaterialCreateRequestDTO(Guid GuidId,Object Value );
    public  record ShellMaterialUpdateRequestDTO(Object Value);
    public  record ShellMaterialDeleteRequestDTO(Guid guid);
}