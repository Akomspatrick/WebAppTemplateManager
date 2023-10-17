using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{
    //public class ModelTypeDTO
    //{
    //    public required string ModelTypeName { get; set; }
    //}
    // convert this to a record
    public record ModelTypeCreateDTO(string ModelTypeId,string ModelTypeName);
    public record ModelTypeUpdateDTO(string ModelTypeId, string ModelTypeName);
    public record ModelTypeRequestDTO(string ModelTypeId);
    public record ModelTypeDeleteDTO(string ModelTypeId);

}
