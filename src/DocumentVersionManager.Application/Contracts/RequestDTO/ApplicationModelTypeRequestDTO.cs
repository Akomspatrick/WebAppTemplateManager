using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    //public class ModelTypeDTO
    //{
    //    public required string ModelTypeName { get; set; }
    //}
    // convert this to a record
    public record ApplicationModelTypeRequestDTO(string ModelTypeId);

    public record ApplicationModelTypeCreateDTO(string ModelTypeId, string ModelTypeName);
    public record ApplicationModelTypeUpdateDTO(string ModelTypeId, string ModelTypeName);
    public record ApplicationModelTypeDeleteDTO(string ModelTypeId);

}
