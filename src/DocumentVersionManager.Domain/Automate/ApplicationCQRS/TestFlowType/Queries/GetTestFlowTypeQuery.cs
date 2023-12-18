using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Queries
{
    public  record GetTestFlowTypeQuery(ApplicationTestFlowTypeGetRequestDTO  RequestTestFlowTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>>;
}