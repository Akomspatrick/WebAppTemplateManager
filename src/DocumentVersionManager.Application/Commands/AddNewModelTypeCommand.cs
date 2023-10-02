using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using MediatR;

namespace DocumentVersionManager.Application.Commands
{
    public record AddNewModelTypeCommand(ModelTypeDTO modelTypeName) : IRequest<int>;

}
