using CoreApiResponse;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("ecommerce")]
    public class ApiController : BaseController
    {
        public IActionResult CustomResultError(List<Error> errors)
        {
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            Log.Information("Error: {Error}", firstError);
            return CustomResult(message: firstError.Description, data: null, code: (System.Net.HttpStatusCode)statusCode);
        }
    }
}
