using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using LanguageExt.Pretty;
using LanguageExt.Pipes;
using LanguageExt.SomeHelp;
using LanguageExt.ClassInstances;
using static LanguageExt.Prelude;





using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Behaviours
{
    public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
           where TResponse : IEither // Specify the type of Result 
    {
        private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

        public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // This can be used to log request and responses through the application

            _logger.LogInformation("Starting request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);

            var result = await next();
            if (result.IsLeft)
            {
                result.MatchUntyped(_ => CreateSuccessLog(result), error => CreateErrorLog(error));
                _logger.LogError("Error occured in request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);
                // var error = result.;
                //if (error is GeneralFailure)
                //{
                //    var generalFailure = error as GeneralFailure;
                //    _logger.LogError("Error occured in request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name,
                //        DateTime.UtcNow);
                //}
                //else if (error is ValidationFailure)
                //{
                //    var validationFailure = error as ValidationFailure;
                //    _logger.LogError("Error occured in request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name,
                //        DateTime.UtcNow);
                //}
                //else
                //{
                //    _logger.LogError("Error occured in request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name,
                //        DateTime.UtcNow);
                //} 
                _logger.LogError("Error occured in request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);

            }
            //if (result != null)
            //{
            // you can check if result is failure here if you are using railway approch 
            // e.g if result.failure ... log failure
            //}
            _logger.LogError("Completed request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);


            return result;
        }

        private object CreateErrorLog(object theerror)
        {
            try
            {
                var error = (GeneralFailure)theerror;

                _logger.LogInformation(DateTime.UtcNow.ToString(), typeof(GeneralFailure).Name, error.Code, error.ErrorType, error.ErrorDescription);

                _logger.LogInformation("{@DateTimeUtc} Completed request {@RequestName} :, {@ErrorCode},{@ErrorType},{@ErrorDescription}", DateTime.UtcNow, typeof(GeneralFailure).Name, error.Code, error.ErrorType, error.ErrorDescription);

            }
            catch (Exception ex)
            {

                throw;
            }
            return theerror;
        }

        private object CreateSuccessLog(object result)
        {
            try
            {
                //var xxx = (GeneralFailure)result;
                _logger.LogInformation("{@DateTimeUtc} Completed request {@RequestName} :, {@ErrorCode},{@ErrorType},{@ErrorDescription} {@DateTimeUtc} was successful ", DateTime.UtcNow);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
