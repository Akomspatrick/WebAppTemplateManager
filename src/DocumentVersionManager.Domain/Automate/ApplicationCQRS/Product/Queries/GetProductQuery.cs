using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Queries
{
    public  record GetProductQuery(ApplicationRequestProductDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseProductDTO>>;
}