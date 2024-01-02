﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Contracts.RequestDTO
{


    public record ModelTypeCreateRequestDTO(Guid GuidId, string ModelTypeName);


    public record ModelTypeUpdateRequestDTO(Guid ModelTypeId, string ModelTypeName);
    public record ModelTypeGetRequestByGuidDTO(Guid ModelTypeId);
    public record ModelTypeGetRequestByIdDTO(string ModelTypeId);
    public record ModelTypeGetRequestDTO(string ModelTypeName);
    public record ModelTypeDeleteRequestDTO(Guid guid);
}