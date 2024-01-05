namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationShellMaterialGetRequestByGuidDTO(ShellMaterialGetRequestByGuidDTO Value);
    public  record ApplicationShellMaterialGetRequestByIdDTO(ShellMaterialGetRequestByIdDTO Value);
    public  record ApplicationShellMaterialGetRequestDTO(ShellMaterialGetRequestDTO Value);
    public  record ApplicationShellMaterialCreateRequestDTO(ShellMaterialCreateRequestDTO Value );
    public  record ApplicationShellMaterialUpdateRequestDTO(ShellMaterialUpdateRequestDTO Value);
    public  record ApplicationShellMaterialDeleteRequestDTO(ShellMaterialDeleteRequestDTO Value);
}