﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Contracts.ResponseDTO
{
    public record ApplicationModelResponseDTO(string ModelId, string ModelTypeId, string ModelTypeName);

}
