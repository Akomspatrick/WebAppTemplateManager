namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestShellMaterialDTO();
    public  record ApplicationRequestShellMaterialByGuidDTO(Guid ShellMaterialGuid);
    public  record ApplicationRequestShellMaterialByIdDTO(string ShellMaterialId);
    public  record ApplicationCreateShellMaterialDTO();
    public  record ApplicationUpdateShellMaterialDTO(Guid ShellMaterialGuid);
    public  record ApplicationDeleteShellMaterialDTO(Guid ShellMaterialGuid);
}