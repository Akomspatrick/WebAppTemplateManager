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
        {

            //return request.EnsureInputIsNotNull("Input Cannot be null")
            //.Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result)
            //.Match<IActionResult>(Left: errors => new OkObjectResult(errors),
            //                      Right: result => result.Match<IActionResult>(
            //                                          Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
            //                                          Right: result2 => new OkObjectResult(result2)
            //                                                                   )
            //                               );


            //var modelType = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new GetAllNewModelTypeQuery(), cancellationToken);
            return x.Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
                        



        }
        //[HttpPost(Name = "GetEither")]
        //public async Task<IActionResult> GetAll(ModelTypeDTO request, CancellationToken cancellationToken)
        //{

        //    return request.EnsureInputIsNotNull("Input Cannot be null")
        //    .Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result)
        //    .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //                          Right: result => result.Match<IActionResult>(
        //                                              Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
        //                                              Right: result2 => new OkObjectResult(result2)
        //                                                                       )
        //                                   );
        //    // improve on the method above
        //    // errors2.Map(x => x.GetEnumDisplayName());

        //}
        [HttpPost("PostEither")]
        public async Task<IActionResult> PostEither2(ModelTypeDTO request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                var x = request.EnsureInputIsNotNull("Input Cannot be null").Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result);
                //var result 
                return null;
            }
            return null;
        }

        private async Task<Either<ModelFailures, int>> AddModelType(ModelTypeDTO modelTypeDTO, CancellationToken cancellationToken)
        {

            var modelType = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            return x;
        }



        [HttpPost("Add")]
        public async Task<IEnumerable<ModelTypeDTO>> Addd(ModelTypeDTO request)
        {
            // var modeltype = new ModelType { ModelTypeName = request.ModelTypeName.ToString() }; 
            if (request != null)
            {
                // convert apidto to applicationdto so that api doesnt leak into application layer.
                var modeltype = new Application.ApplicationDTO.RequestDTO.ApplicationModelTypeRequestDTO(request.ModelTypeName);
                var command = new AddNewModelTypeCommand(modeltype);
                var result = await _mediator.Send(command);
            }

            return null;
        }

    }
}
