using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Commands;
using DocumentVersionManager.Application.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

            return request.EnsureInputIsNotNull("Input Cannot be null")
            .Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                  Right: result => result.Match<IActionResult>(
                                                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                                                      Right: result2 => new OkObjectResult(result2)
                                                                               )
                                           );
            // improve on the method above
            // errors2.Map(x => x.GetEnumDisplayName());

        }


        [HttpGet(Name = "GetEither")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {   var request = new ModelTypeDTO("string");
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            //var xp = request.EnsureInputIsNotNull("Input Cannot be null")
            //.Bind<Either<ModelFailures, Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO>>(request => GetAllNewModelT(request, cancellationToken)
            //.Match<IActionResult>(Left: errors => new OkObjectResult(errors),
            //                      Right: result => result.Match<IActionResult>(
            //                                          Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
            //                                          Right: result2 => new OkObjectResult(result2)
            //  )));
            return (await _mediator.Send(new GetNewModelTypeQuery(new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO ("778")), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }

        private Task<Either<ModelFailures, int>> GetAllNewModelT(ModelTypeDTO request, CancellationToken cancellationToken)
        {
            //var modelType = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
            //var x = await _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            //return x;
            return null;
        }

        [HttpGet( template: "GetAllAsync", Name = "GetAllEither")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {

          
            return (await _mediator.Send(new GetAllNewModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<ModelFailures, int>> AddModelType(ModelTypeDTO modelTypeDTO, CancellationToken cancellationToken)
        {

            var modelType = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            return x;
        }


        //[HttpPost("PostEither")]
        //public async Task<IActionResult> PostEither2(ModelTypeDTO request, CancellationToken cancellationToken)
        //{

        //    if (request != null)
        //    {
        //        var x = request.EnsureInputIsNotNull("Input Cannot be null").Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result);
        //        //var result 
        //        return null;
        //    }
        //    return null;
        //}




        //[HttpPost("Add")]
        //public async Task<IEnumerable<ModelTypeDTO>> Addd(ModelTypeDTO request)
        //{
        //    // var modeltype = new ModelType { ModelTypeName = request.ModelTypeName.ToString() }; 
        //    if (request != null)
        //    {
        //        // convert apidto to applicationdto so that api doesnt leak into application layer.
        //        var modeltype = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(request.ModelTypeName);
        //        var command = new AddNewModelTypeCommand(modeltype);
        //        var result = await _mediator.Send(command);
        //    }

        //    return null;
        //}

    }
}
