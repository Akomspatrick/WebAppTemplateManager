using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Queries{
    public  record GetTestFlowTypeQuery(TestFlowTypeGetRequestDTO  RequestTestFlowTypeDTO) :  IRequest<Either<GeneralFailure, TestFlowTypeResponseDTO>>;
    public  record GetTestFlowTypeByGuidQuery(TestFlowTypeGetRequestByGuidDTO  RequestTestFlowTypeDTO) :  IRequest<Either<GeneralFailure, TestFlowTypeResponseDTO>>;
    public  record GetTestFlowTypeByIdQuery(TestFlowTypeGetRequestByIdDTO  RequestTestFlowTypeDTO) :  IRequest<Either<GeneralFailure, TestFlowTypeResponseDTO>>;
    public  record GetAllTestFlowTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<TestFlowTypeResponseDTO>>>;
}