using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using DocumentVersionManager.Application.ApplicationDTO.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Queries.ModelType
{
    public record GetAllModelTypeQuery : IRequest<Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>>;

}
