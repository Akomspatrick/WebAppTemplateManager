using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.Model.Commands
{
    // public record CreateModelCommand(ApplicationModelCreateDTO ModelCreateDTO) :  IRequest<Either<GeneralFailure, int>>;
    public record CreateModelCommand(ApplicationModelCreateRequestDTO CreateModelDTO) : IRequest<Either<GeneralFailure, Guid>>;
}
