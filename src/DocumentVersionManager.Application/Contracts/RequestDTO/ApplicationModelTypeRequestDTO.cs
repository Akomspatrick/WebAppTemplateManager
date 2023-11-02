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
    public record ApplicationModelTypeRequestDTOByGuidId(Guid modelTypesId);
    public record ApplicationModelTypeRequestDTO(string modelTypesName);
    public record ApplicationModelTypeCreateDTO(string modelTypesName);
    public record ApplicationModelTypeUpdateDTO(Guid modelTypesId, string modelTypesName);
    public record ApplicationModelTypeDeleteDTO(Guid modelTypesId);

}
