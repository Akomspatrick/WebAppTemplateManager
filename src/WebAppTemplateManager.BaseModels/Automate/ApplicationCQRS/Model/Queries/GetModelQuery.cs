using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Queries{
    public  record GetModelQuery(ModelGetRequestDTO  RequestModelDTO) :  IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public  record GetModelByGuidQuery(ModelGetRequestByGuidDTO  RequestModelDTO) :  IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public  record GetModelByIdQuery(ModelGetRequestByIdDTO  RequestModelDTO) :  IRequest<Either<GeneralFailure, ModelResponseDTO>>;
    public  record GetAllModelQuery :  IRequest<Either<GeneralFailure, IEnumerable<ModelResponseDTO>>>;
}