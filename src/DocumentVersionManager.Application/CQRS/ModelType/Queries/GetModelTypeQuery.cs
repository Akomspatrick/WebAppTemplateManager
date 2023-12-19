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

namespace DocumentVersionManager.Application.CQRS.ModelType.Queries
{

    public record GetModelTypeQuery(ApplicationModelTypeGetRequestDTO modelTypeRequestDTO) : IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public record GetModelTypeByGuidQuery(ApplicationModelTypeGetRequestByGuidDTO modelTypeRequestDTO) : IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public record GetModelTypeByIdQuery(ApplicationModelTypeGetRequestByIdDTO modelTypeRequestDTO) : IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public record GetAllModelTypeQuery : IRequest<Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>;

}
