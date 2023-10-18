using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.RequestDTO
{


    public record ApplicationModelRequestDTO(string ModelId);

    public record ApplicationModelCreateDTO(string ModelId, string ModelTypeId, string ModelTypeName);
    public record ApplicationModelUpdateDTO(string ModelId, string ModelTypeId, string ModelTypeName);
    public record ApplicationModelDeleteDTO(string ModelId);
}
