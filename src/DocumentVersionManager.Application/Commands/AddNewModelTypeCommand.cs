using DocumentVersionManager.Contracts.RequestDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Commands
{
    public record AddNewModelTypeCommand(ModelTypeDTO modelType):IRequest<int>;
    
}
