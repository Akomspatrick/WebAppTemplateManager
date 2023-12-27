using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{
    public class EitherActionResultOld : IActionResult
    {

        public Either<GeneralFailure, int> Value { get; set; }
        public int? StatusCode { get; set; }
        object response = null;
        public EitherActionResultOld(Either<GeneralFailure, int> value)
        {
            // Value = value;
            object response = null;
            if (value.IsLeft)
            {
                response = new { errors = value };
                StatusCode = 400;
            }
            else
            {
                response = new { data = value };
                StatusCode = 200;
            }
        }



        public async Task ExecuteResultAsync(ActionContext context)
        {

            var result = new ObjectResult(this.response);

            await result.ExecuteResultAsync(context);
        }

    }
}
