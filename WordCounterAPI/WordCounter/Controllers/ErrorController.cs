using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using WordCounter.Extensions.Exceptions;

namespace WordCounterAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        private readonly ILogger _logger;
        public ErrorController(ILogger logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            _logger.LogError(exception, exception.Message);

            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is ValidationProblemException)
                statusCode = (int)HttpStatusCode.BadRequest;

            return Problem(exception.Message, null, statusCode);
        }
    }
}
