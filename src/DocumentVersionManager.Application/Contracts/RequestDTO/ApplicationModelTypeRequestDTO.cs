using DocumentVersionManager.Contracts.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    //public class ModelTypeDTO
    //{
    //    public required string modelTypesName { get; set; }
    //}
    // convert this to a record
    //public record ApplicationModelTypeRequestByGuidDTO(Guid ModelTypesId);
    //public record ApplicationModelTypeRequestByIdDTO(string ModelTypesId);
    //public record ApplicationModelTypeRequestDTO(string ModelTypesName);

    //public record ApplicationModelTypeCreateDTO(string ModelTypesName);
    //public record ApplicationModelTypeUpdateDTO(Guid ModelTypesId, string modelTypesName);
    //public record ApplicationModelTypeDeleteDTO(Guid ModelTypesId);


    public record ApplicationModelTypeGetRequestByGuidDTO(ModelTypeGetRequestByGuidDTO Value);
    public record ApplicationModelTypeGetRequestByIdDTO(ModelTypeGetRequestByIdDTO Value);
    public record ApplicationModelTypeGetRequestDTO(ModelTypeGetRequestDTO Value);

    public record ApplicationModelTypeCreateRequestDTO(ModelTypeCreateRequestDTO Value);
    public record ApplicationModelTypeUpdateRequestDTO(ModelTypeUpdateRequestDTO Value);
    public record ApplicationModelTypeDeleteRequestDTO(ModelTypeDeleteRequestDTO Value);



}
