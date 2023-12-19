using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelType.Queries{
    public  record GetModelTypeQuery(ApplicationModelTypeGetRequestDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public  record GetModelTypeByGuidQuery(ApplicationModelTypeGetRequestByGuidDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public  record GetModelTypeByIdQuery(ApplicationModelTypeGetRequestByIdDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>;
    public  record GetAllModelTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>;
}