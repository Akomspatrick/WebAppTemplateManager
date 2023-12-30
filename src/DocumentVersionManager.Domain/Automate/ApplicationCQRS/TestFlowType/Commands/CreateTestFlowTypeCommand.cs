using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Commands
{
    public  record CreateTestFlowTypeCommand(TestFlowTypeCreateRequestDTO  CreateTestFlowTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}