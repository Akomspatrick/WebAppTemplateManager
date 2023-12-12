using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.TestFlowType.Commands;
using DocumentVersionManager.Application.CQRS.TestFlowType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using  MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class TestFlowTypesController  : DVBaseController<TestFlowTypesController>
    {
        public TestFlowTypesController(ILogger<TestFlowTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Create, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Create)]
        public async Task<IActionResult> Create(TestFlowTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestFlowTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateTestFlowType(ApplicationTestFlowTypeCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTestFlowTypeCommand(createdDto), cancellationToken);
    }
}