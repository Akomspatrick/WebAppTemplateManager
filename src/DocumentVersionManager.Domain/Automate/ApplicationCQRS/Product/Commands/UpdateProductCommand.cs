using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Commands
{
    public  record UpdateProductCommand(ProductUpdateRequestDTO  UpdateProductDTO) :  IRequest<Either<GeneralFailure, int>>;
}