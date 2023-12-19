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

namespace DocumentVersionManager.Application.CQRS.Model.Queries
{

    public record GetModelQuery(ApplicationModelGetRequestDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ApplicationModelResponseDTO>>;
    public record GetModelByGuidQuery(ApplicationModelGetRequestByGuidDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ApplicationModelResponseDTO>>;
    public record GetModelByIdQuery(ApplicationModelGetRequestByIdDTO RequestModelDTO) : IRequest<Either<GeneralFailure, ApplicationModelResponseDTO>>;
    public record GetAllModelQuery : IRequest<Either<GeneralFailure, IEnumerable<ApplicationModelResponseDTO>>>;
}
