using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DocumentVersionManager.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ModelTypeController : ControllerBase
    {
        private readonly ILogger<ModelTypeController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public ModelTypeController(ILogger<ModelTypeController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "PostEither")]
        public async Task<IActionResult> Post(ModelTypeDTO request, CancellationToken cancellationToken)
        {

            return request.EnsureInputIsNotNull("Input Cannot be null")//.EnsureInputIsNotEmpty("Input Cannot be empty")
            .Bind<Either<GeneralFailures, int>>(request => AddModelType(request, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                  Right: result => result.Match<IActionResult>(
                                                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                                                      Right: result2 => new OkObjectResult(result2)
                                                                               )
                                           );


        }

        [HttpGet(Name = "GetEither")]
        public async Task<IActionResult> Get([FromBody] ModelTypeDTO request, CancellationToken cancellationToken)
        {   //var request = new ModelTypeDTO("string");
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            //var xp = request.EnsureInputIsNotNull("Input Cannot be null")
            //.Bind<Either<ModelFailures, Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO>>(request => GetAllNewModelT(request, cancellationToken)
            //.Match<IActionResult>(Left: errors => new OkObjectResult(errors),
            //                      Right: result => result.Match<IActionResult>(
            //                                          Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
            //                                          Right: result2 => new OkObjectResult(result2)
            //  )));
            return (await _mediator.Send(new GetModelTypeQuery(new ApplicationModelTypeRequestDTO (request.ModelTypeId,request.ModelTypeName)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }


        [HttpGet( template: "GetAllAsync", Name = "GetAllEither")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {

          
            return (await _mediator.Send(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailures, int>> AddModelType(ModelTypeDTO modelTypeDTO, CancellationToken cancellationToken)
        {

            var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeId,modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            return x;
        }



    }
}
