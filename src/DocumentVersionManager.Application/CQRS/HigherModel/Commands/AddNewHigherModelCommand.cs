using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.HigherModel.Commands
{
    public record AddNewHigherModelCommand(String HigherModelName, string HigherModelDescription, string ProductId, int Capacity) : IRequest<ApplicationModelTypeRequestDTO>;
    // record AddNewHigherModelCommand(ApplicationModelTypeRequestDTO modelTypeName) : IRequest<Either<GeneralFailures, int>>;
}
