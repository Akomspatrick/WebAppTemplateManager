using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.DocumentType.Commands
{
    public record AddNewDocumentTypeCommand(ApplicationDocumentTypeRequestDTO documentTypeName) : IRequest<Either<GeneralFailures, int>>;

}
